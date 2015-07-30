using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    class Mage:Unit
    {
        private const int mageDefaultAttackPoints = 80;
        private const int mageDefaultHealthPoints = 80;
        private const int mageDefaultDefensePoints = 40;
        private const int mageDefaultEnergyPoints = 120;
        private const int mageDefaultRange = 2;

        public Mage(string name, int x, int y) : base(name, x, y, mageDefaultRange, mageDefaultAttackPoints, mageDefaultHealthPoints, mageDefaultDefensePoints, mageDefaultEnergyPoints)
        {
            this.CombatHandler=new MageCombatHandler(this);
        }
    }
}
