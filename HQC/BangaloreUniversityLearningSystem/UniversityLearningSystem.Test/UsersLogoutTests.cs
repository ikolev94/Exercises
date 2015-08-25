namespace UniversityLearningSystem.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using UniversityLearningSystem.Controllers;
    using UniversityLearningSystem.Data;
    using UniversityLearningSystem.Interfaces;
    using UniversityLearningSystem.Models;

    [TestClass]
    public class UsersLogoutTests
    {

        private IBangaloreUniversityDate data;

        private UsersController usersController;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUsersLogoutWhitNullUser()
        {
            this.data = new BangaloreUniversityDate();
            this.usersController = new UsersController(this.data, null);
            this.usersController.Logout();
        }

    }
}
