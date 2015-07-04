using System;
using System.Text;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser user)
            : base(id, body, user)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("[ Answer ID: {0} ]{1}", this.Id, Environment.NewLine);
            result.AppendFormat("Posted by: {0}{1}", this.Author.Username, Environment.NewLine);
            result.AppendFormat("Answer Body: {0}{1}", this.Body, Environment.NewLine);
            result.Append(new string('-', Delimiter));
            return result.ToString();
        }
    }
}
