namespace UniversityLearningSystem.Controllers
{
    using System;

    using UniversityLearningSystem.Interfaces;
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Utilities;
    using UniversityLearningSystem.Views.UserViews;

    /// <summary>Contains methods for working whit users</summary>
    public class UsersController : Controller
    {
        /// <summary>Initializes a new instance of the <see cref="UsersController"/> class.</summary>
        /// <param name="data">The data.</param>
        /// <param name="user">The user.</param>
        public UsersController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        /// <summary>register user in the database</summary>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <param name="confirmPassword">The confirm password.</param>
        /// <param name="role">The role.</param>
        /// <returns>
        /// success message if registration succeeds or throw exception otherwise.
        /// <see cref="IView"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return new RegisterView(user);
        }

        /// <summary>login user in the database.</summary>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>success message if login succeeds or throw exception otherwise.
        /// <see cref="IView"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            this.User = existingUser;
            return new LoginView(existingUser);
        }

        /// <summary>logout user</summary>
        /// <returns>
        /// success message if logout succeeds or throw exception otherwise.
        /// <see cref="IView"/>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="DivideByZeroException"></exception>
        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                throw new ArgumentException("The current user is not authorized to perform this operation.");
            }

            var user = this.User;
            this.User = null;
            return new LogoutView(user);
        }

        /// <summary>Ensure that their is logged in user.</summary>
        /// <exception cref="ArgumentException"></exception>
        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}