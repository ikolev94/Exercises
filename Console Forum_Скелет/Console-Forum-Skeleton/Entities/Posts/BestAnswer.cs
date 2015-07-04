using System;
using System.Text;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser user)
            : base(id, body, user)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string('*', Delimiter));
            result.AppendLine(base.ToString());
            result.AppendLine(new string('*', Delimiter));

            return result.ToString();
        }
    }
}
