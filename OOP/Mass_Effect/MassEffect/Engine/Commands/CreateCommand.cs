using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string typeString = commandArgs[1];
            string shipNameString = commandArgs[2];
            string locationString = commandArgs[3];

            StarshipType type = (StarshipType) Enum.Parse(typeof (StarshipType), typeString);
            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationString);

            var ship = this.GameEngine.ShipFactory.CreateShip(type, shipNameString,location);
           
            for (int i = 4; i < commandArgs.Length; i++)
            {
                string enhancementName = commandArgs[i];

                EnhancementType enhancementType = (EnhancementType) Enum.Parse(typeof (EnhancementType), enhancementName);
                var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                ship.AddEnhancement(enhancement);
                
            }
            if (GameEngine.Starships.Any(s=>s.Name==shipNameString))
            {
                throw new ShipException(String.Format(Messages.DuplicateShipName));
            }
            this.GameEngine.Starships.Add(ship);
            Console.WriteLine(Messages.CreatedShip,typeString,shipNameString);
        }
    }
}
