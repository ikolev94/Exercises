namespace UniversityLearningSystem.Views
{
    using System.Text;

    using UniversityLearningSystem.Interfaces;

    public abstract class View : IView
    {
        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        public abstract void BuildViewResult(StringBuilder viewResult);
    }
}
