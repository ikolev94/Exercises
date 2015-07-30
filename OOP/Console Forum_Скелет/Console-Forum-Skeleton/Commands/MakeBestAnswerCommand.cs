using System;
using System.Linq;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class MakeBestAnswerCommand:AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            ValidateLoginUser();
            ValidateQuestion();
            if (Forum.CurrentUser!=Forum.CurrentQuestion.Author&&!(Forum.CurrentUser is IAdministrator))
            {
                throw new CommandException(Messages.NoPermission);
            }
            var question = this.Forum.CurrentQuestion;
            int id = int.Parse(this.Data[1]);
            var answer =question.Answers.FirstOrDefault(a => a.Id == id);           
            if (answer==null)
            {
                throw new CommandException(Messages.NoAnswer);
            }
            var previousBest = question.Answers.FirstOrDefault(a => a is BestAnswer);
            if (previousBest!=null&&previousBest!=answer)
            {
                question.Answers.Add(new Answer(previousBest.Id,previousBest.Body,previousBest.Author));
                question.Answers.Remove(previousBest);
            }
            question.Answers.Add(new BestAnswer(answer.Id,answer.Body,answer.Author));
            question.Answers.Remove(answer);
            Forum.Output.AppendLine(String.Format(Messages.BestAnswerSuccess, answer.Id));
        }
    }
}
