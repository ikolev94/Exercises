using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Cruiser:StarShip
    {
        private const int CruiserHealth = 100;
        private const int CruiserShields = 100;
        private const int CruiserDamage = 50;
        private const int CruiserFuel = 300;
        public Cruiser(string name, StarSystem locatiin) : base(name, CruiserHealth, CruiserShields, CruiserDamage, CruiserFuel, locatiin)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
