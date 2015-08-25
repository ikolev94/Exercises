namespace UniversityLearningSystem.Data
{
    using UniversityLearningSystem.Interfaces;
    using UniversityLearningSystem.Models;

    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public BangaloreUniversityDate()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; private set; }

        public IRepository<Course> Courses { get; private set; }
    }
}
