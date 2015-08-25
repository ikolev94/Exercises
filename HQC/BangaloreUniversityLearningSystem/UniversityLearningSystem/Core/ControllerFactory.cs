namespace UniversityLearningSystem.Core
{
    using UniversityLearningSystem.Controllers;
    using UniversityLearningSystem.Interfaces;
    using UniversityLearningSystem.Models;

    public class ControllerFactory
    {
        public Controller Create(string controllerType, IBangaloreUniversityDate data, User user)
        {
            switch (controllerType)
            {
                case "UsersController":
                    return new UsersController(data, user);
                case "CoursesController":
                    return new CoursesController(data, user);
            }

            return null;
        }
    }
}
