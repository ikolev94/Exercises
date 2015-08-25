namespace UniversityLearningSystem.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using UniversityLearningSystem.Models;

    public class AllView : View
    {
        public AllView(IEnumerable<Course> courses)
        {
            this.Courses = courses;
        }

        public IEnumerable<Course> Courses { get; set; }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Courses;
            if (!courses.Any())
            {
                viewResult.AppendLine("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students)", course.Name, course.Students.Count).AppendLine();
                }
            }
        }
    }
}