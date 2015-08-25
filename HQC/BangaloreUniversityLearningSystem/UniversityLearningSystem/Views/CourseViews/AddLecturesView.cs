namespace UniversityLearningSystem.Views.CourseViews
{
    using System.Text;

    using UniversityLearningSystem.Models;

    public class AddLecturesView : CourseView
    {
        public AddLecturesView(Course course)
            : base(course)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}