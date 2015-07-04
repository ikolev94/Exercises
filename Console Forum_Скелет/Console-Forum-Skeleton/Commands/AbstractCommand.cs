namespace ConsoleForum.Commands
{
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public abstract class AbstractCommand : ICommand
    {
        public readonly List<string> Data = new List<string>();

        protected AbstractCommand(IForum forum)
        {
            this.Forum = forum;
        }

        public IForum Forum { get; private set; }

        public abstract void Execute();

        protected void ValidateLoginUser()
        {
            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
        protected void ValidateQuestion()
        {
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
        }
    }
}
