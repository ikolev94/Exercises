using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Locations;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string starSystem = commandArgs[2];

            IStarship ship = null;
            ship = this.GameEngine.Starships.First(starship => starship.Name == shipName);
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }

            var previousLocation = ship.Location;
            StarSystem destination = null;
            destination = this.GameEngine.Galaxy.StarSystems.First(system => system.Name == starSystem);

            if (previousLocation.Name == destination.Name)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destination.Name));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);
            Console.WriteLine(Messages.ShipTraveled, ship.Name, previousLocation.Name, destination.Name);
        }
    }
}
