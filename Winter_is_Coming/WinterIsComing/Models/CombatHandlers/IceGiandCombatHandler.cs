using System;
using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    class IceGiandCombatHandler : CombatHandler
    {
        public IceGiandCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                return candidateTargets.Take(1);
            }

            return candidateTargets;
        }

        public override ISpell GenerateAttack()
        {
            int damage = this.Unit.AttackPoints;
            var attack = new Stomp(damage);
            this.ValidateEnergy(attack);
            this.Unit.AttackPoints += 5;
            this.Unit.EnergyPoints -= attack.EnergyCost;
            return attack;
        }
    }
}
