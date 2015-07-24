using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    class WarriorCombatHandler : CombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            return candidateTargets
                .OrderBy(target => target.HealthPoints)
                .ThenBy(target => target.Name)
                .Take(1);
        }

        public override ISpell GenerateAttack()
        {
            int damage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= 80)
            {
                damage += this.Unit.HealthPoints * 2;
            }

            var attack = new Cleave(damage);
            if (this.Unit.HealthPoints > 50)
            {
                this.ValidateEnergy(attack);
                this.Unit.EnergyPoints -= attack.EnergyCost;
            }

            return attack;
        }
    }
}
