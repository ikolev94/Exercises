using System;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.Questions.Count==0)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {
                foreach (var question in this.Forum.Questions)
                {
                    this.Forum.Output.Append(question.ToString());
                }
            }

            this.Forum.CurrentQuestion = null;
        }
    }
}
