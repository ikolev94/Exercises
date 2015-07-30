using System;
using System.Collections.Generic;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.CombatHandlers
{
   public abstract class CombatHandler:ICombatHandler
    {
       protected CombatHandler(IUnit unit)
       {
           this.Unit = unit;
       }

       public IUnit Unit { get; set; }

       public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

       public abstract ISpell GenerateAttack();

       public void ValidateEnergy(ISpell attack)
       {
           if (this.Unit.EnergyPoints - attack.EnergyCost < 0)
           {
               throw new NotEnoughEnergyException(String.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name,
                   attack.GetType().Name));
           }
       }
    }
}
