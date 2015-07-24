using System;
using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    class MageCombatHandler : CombatHandler
    {
        private int attacksCounter;
        public MageCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            return candidateTargets
                .OrderByDescending(target => target.HealthPoints)
                .ThenBy(target => target.Name)
                .Take(3);
        }

        public override ISpell GenerateAttack()
        {
            ISpell attack;
            if (this.attacksCounter % 2 == 0)
            {
                attack = new FireBreath(this.Unit.AttackPoints);
            }
            else
            {
                attack = new Blizzard(this.Unit.AttackPoints * 2);
            }

            this.ValidateEnergy(attack);
            this.attacksCounter++;
            this.Unit.EnergyPoints -= attack.EnergyCost;

            return attack;
        }
    }
}
