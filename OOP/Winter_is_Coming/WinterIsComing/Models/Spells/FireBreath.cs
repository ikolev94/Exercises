namespace WinterIsComing.Models.Spells
{

    public class FireBreath : Spell
    {
        private const int defaultEnergyCost = 30;
        public FireBreath(int damage)
            : base(damage, defaultEnergyCost)
        {
        }
    }
}
