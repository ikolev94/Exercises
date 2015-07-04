using System;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand:AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            int qustionId = int.Parse(this.Data[1]);
            var question = this.Forum.Questions.FirstOrDefault(q => q.Id == qustionId);
            if (question==null)
            {
                throw new CommandException(Messages.NoQuestion);
            }
            this.Forum.CurrentQuestion = question;
            
            this.Forum.Output.Append(question.ToString());
            
        }
    }
}
