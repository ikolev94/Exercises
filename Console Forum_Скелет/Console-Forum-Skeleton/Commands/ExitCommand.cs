using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class ExitCommand:AbstractCommand
    {
        public ExitCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.HasStarted = false;
        }
    }
}
