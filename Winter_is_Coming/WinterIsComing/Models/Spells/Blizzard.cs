namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        private const int defaultEnergyCost = 40;
        public Blizzard(int damage)
            : base(damage, defaultEnergyCost)
        {
        }
    }
}
