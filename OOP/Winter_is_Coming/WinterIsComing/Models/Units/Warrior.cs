using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    class Warrior:Unit
    {
        private const int warriorDefaultAttackPoints = 120;
        private const int warriorDefaultHealthPoints = 180;
        private const int warriorDefaultDefensePoints = 70;
        private const int warriorDefaultEnergyPoints = 60;
        private const int warriorDefaultRange = 1;

        public Warrior(string name, int x, int y) : base(name, x, y, warriorDefaultRange, warriorDefaultAttackPoints, warriorDefaultHealthPoints, warriorDefaultDefensePoints, warriorDefaultEnergyPoints)
        {
            this.CombatHandler=new WarriorCombatHandler(this);
        }

    }
}
