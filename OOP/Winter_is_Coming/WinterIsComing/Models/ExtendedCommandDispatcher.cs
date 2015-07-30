using WinterIsComing.Core;
using WinterIsComing.Core.Commands;

namespace WinterIsComing.Models
{
    class ExtendedCommandDispatcher:CommandDispatcher
    {
        public override void SeedCommands()
        {
            
            base.SeedCommands();
            this.commandsByName["toggle-effector"]=new ToggleEffectorCommand(this.Engine);
        }
    }
}
