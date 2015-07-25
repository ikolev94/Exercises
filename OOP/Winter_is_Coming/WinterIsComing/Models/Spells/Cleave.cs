namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        private const int defaultEnergyCost = 15;
        public Cleave(int damage)
            : base(damage, defaultEnergyCost)
        {
        }
    }
}
