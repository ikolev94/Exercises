using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            ValidateLoginUser();
            ValidateQuestion();
            string answerBody = this.Data[1];
            int id = this.Forum.Answers.Count + 1;
            IAnswer anwser = new Answer(id, answerBody, this.Forum.CurrentUser);
            this.Forum.CurrentQuestion.Answers.Add(anwser);
            this.Forum.Answers.Add(anwser);
            this.Forum.Output.AppendLine(String.Format(Messages.PostAnswerSuccess, anwser.Id));
        }
    }
}
