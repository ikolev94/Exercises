namespace UniversityLearningSystem.Views.UserViews
{
    using System.Text;

    using UniversityLearningSystem.Models;

    public class LogoutView : UserView
    {
        public LogoutView(User user)
            : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged out successfully.", this.User.Username).AppendLine();
        }
    }
}