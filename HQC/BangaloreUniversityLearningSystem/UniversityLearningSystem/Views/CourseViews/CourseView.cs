namespace UniversityLearningSystem.Views.CourseViews
{
    using UniversityLearningSystem.Models;

    public abstract class CourseView : View
    {
        protected CourseView(Course course)
        {
            this.Course = course;
        }

        public Course Course { get; private set; }
    }
}
