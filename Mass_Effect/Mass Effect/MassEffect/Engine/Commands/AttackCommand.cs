using System;
using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attakerName = commandArgs[1];
            string deffenderName = commandArgs[2];

            var attacker = this.GameEngine.Starships.FirstOrDefault(s => s.Name == attakerName);
            this.Validate(attacker);
            var deffender = this.GameEngine.Starships.FirstOrDefault(s => s.Name == deffenderName);
            this.Validate(deffender);
            if (attacker.Location.Name != deffender.Location.Name)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }
            var ammo = attacker.ProduceAttack();
            deffender.RespondToAttack(ammo);
            Console.WriteLine(Messages.ShipAttacked, attakerName, deffenderName);
            if (deffender.Shields < 0)
            {
                deffender.Shields = 0;
            }
            if (deffender.Health <= 0)
            {
                deffender.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, deffender.Name);
            }
        }

        private void Validate(IStarship ship)
        {
            if (ship == null)
            {
                throw new ShipException("Ship is null");
            }
            if (ship.Health <= 0)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyDestroyed));
            }
        }
    }
}
