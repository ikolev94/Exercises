namespace UniversityLearningSystem.Views.UserViews
{
    using System.Text;

    using UniversityLearningSystem.Models;

    public class RegisterView : UserView
    {
        public RegisterView(User user)
            : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", this.User.Username).AppendLine();
        }
    }
}
