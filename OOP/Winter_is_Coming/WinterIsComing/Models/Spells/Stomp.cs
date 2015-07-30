namespace WinterIsComing.Models.Spells
{
    class Stomp:Spell
    {
        private const int defaultEnergyCost = 10;
        public Stomp(int damage) : base(damage, defaultEnergyCost)
        {
        }
    }
}
