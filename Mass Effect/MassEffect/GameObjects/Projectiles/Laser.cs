using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    class Laser:Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            int damageLeft = this.Damage - ship.Shields;
            ship.Shields -= this.Damage;
            if (damageLeft>0)
            {
                ship.Health -= damageLeft;
            }
        }
    }
}
