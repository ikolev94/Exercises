namespace UniversityLearningSystem.Views.UserViews
{
    using UniversityLearningSystem.Models;

    public abstract class UserView : View
    {
        protected UserView(User user)
        {
            this.User = user;
        }

        public User User { get; private set; }
    }
}
