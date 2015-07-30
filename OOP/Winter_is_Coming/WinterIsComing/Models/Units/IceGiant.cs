using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    class IceGiant:Unit
    {
        private const int iceGiantDefaultAttackPoints = 150;
        private const int iceGiantDefaultHealthPoints = 300;
        private const int iceGiantDefaultDefensePoints = 60;
        private const int iceGiantDefaultEnergyPoints = 50;
        private const int iceGiantDefaultRange = 1;

        public IceGiant(string name, int x, int y) : base(name, x, y, iceGiantDefaultRange, iceGiantDefaultAttackPoints, iceGiantDefaultHealthPoints, iceGiantDefaultDefensePoints, iceGiantDefaultEnergyPoints)
        {
            this.CombatHandler=new IceGiandCombatHandler(this);
        }
    }
}
