namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;
    
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Views.CourseViews;

    public class CreateView : CourseView
    {
        public CreateView(Course course)
            : base(course)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}