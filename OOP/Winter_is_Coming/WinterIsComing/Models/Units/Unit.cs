using System;
using System.Text;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit:IUnit
    {
        protected Unit(string name,int x,int y,int range,int attackPoints,int healthPoints,int defensePoints,int energy)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.EnergyPoints = energy;
            
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; private set; }
        public int Range { get; private set; }
        public int AttackPoints { get; set; }
        public int HealthPoints { get; set; }
        public int DefensePoints { get; set; }
        public int EnergyPoints { get; set; }
        public ICombatHandler CombatHandler { get; protected set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(String.Format(">{0} - {1} at ({2},{3})", this.Name, this.GetType().Name, this.X,
                    this.Y));
            if (this.HealthPoints>0)
            {
                output.AppendLine(String.Format("-Health points = {0}", this.HealthPoints));
                output.AppendLine(String.Format("-Attack points = {0}", this.AttackPoints));
                output.AppendLine(String.Format("-Defense points = {0}", this.DefensePoints));
                output.AppendLine(String.Format("-Energy points = {0}", this.EnergyPoints));
                output.Append(String.Format("-Range = {0}", this.Range));
            }
            else
            {
                output.Append("(Dead)");
            }
            return output.ToString();
        }
    }
}
