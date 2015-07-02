using System;
using System.Text;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : StarShip
    {
        private const int FrigateHealth = 60;
        private const int FrigateShields = 50;
        private const int FrigateDamage = 30;
        private const int FrigateFuel = 220;
        private int firedProjectiles;

        public Frigate(string name, StarSystem locatiin)
            : base(name, FrigateHealth, FrigateShields, FrigateDamage, FrigateFuel, locatiin)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var attack = new ShieldReaver(this.Damage);
            firedProjectiles++;
            return attack;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            if (this.Health > 0)
            {
                output.Append(string.Format("\n-Projectiles fired: {0}", this.firedProjectiles));
            }
            return output.ToString();
        }
    }
}
