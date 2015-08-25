namespace UniversityLearningSystem.Views.CourseViews
{
    using System.Text;

    using UniversityLearningSystem.Models;

    public class EnrollView : CourseView
    {
        public EnrollView(Course course)
            : base(course)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.", course.Name).AppendLine();
        }
    }
}