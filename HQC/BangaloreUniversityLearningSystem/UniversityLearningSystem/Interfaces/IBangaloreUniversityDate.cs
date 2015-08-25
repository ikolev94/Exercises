namespace UniversityLearningSystem.Interfaces
{
    using UniversityLearningSystem.Data;
    using UniversityLearningSystem.Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}