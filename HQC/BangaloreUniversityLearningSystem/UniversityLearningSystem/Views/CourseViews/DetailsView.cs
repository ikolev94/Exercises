namespace UniversityLearningSystem.Views.CourseViews
{
    using System;
    using System.Linq;
    using System.Text;

    using UniversityLearningSystem.Models;

    public class DetailsView : CourseView
    {
        public DetailsView(Course course)
            : base(course)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Course;
            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                var lectureNames = course.Lectures.Select(l => "- " + l.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}