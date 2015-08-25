namespace UniversityLearningSystem.Views.UserViews
{
    using System.Text;

    using UniversityLearningSystem.Models;

    public class LoginView : UserView
    {
        public LoginView(User user)
            : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", this.User.Username).AppendLine();
        }
    }
}