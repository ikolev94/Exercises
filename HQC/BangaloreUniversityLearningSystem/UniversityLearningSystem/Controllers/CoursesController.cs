namespace UniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Views;

    using UniversityLearningSystem.Interfaces;
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Utilities;
    using UniversityLearningSystem.Views;
    using UniversityLearningSystem.Views.CourseViews;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return new AllView(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.CourseGetter(courseId);
            if (!this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return new DetailsView(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.CourseGetter(courseId);

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);
            return new EnrollView(course);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var c = new Course(name);
            this.Data.Courses.Add(c);
            return new CreateView(c);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            Course c = this.CourseGetter(courseId);
            c.AddLecture(new Lecture(lectureName));
            return new AddLecturesView(c);
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }
    }
}