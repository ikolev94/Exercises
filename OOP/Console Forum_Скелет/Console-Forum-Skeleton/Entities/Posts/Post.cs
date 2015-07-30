using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    abstract class Post:IPost
    {
        public const int Delimiter = 20;
        protected Post(int id,string body,IUser user)
        {
            this.Id = id;
            this.Author = user;
            this.Body = body;
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public IUser Author { get; set; }
    }
}
