using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuhtigIssueTracker.Test
{
    [TestClass]
    public class RegisterUserTest : Test
    {
        [TestMethod]
        public void TestRegisterUser_ShouldReturnRegisterUser()
        {
            string resultView = this.tracker.RegisterUser("admin", "password", "password");
            Assert.AreEqual("User admin registered successfully", resultView);
        }

        [TestMethod]
        public void TestRegisterUser_WithWrongPassword()
        {
            string resultView = this.tracker.RegisterUser("admin", "password", "password1");
            Assert.AreEqual("The provided passwords do not match", resultView);
        }

        [TestMethod]
        public void TestRegisterUser_WithAlreadyaLoggedInUser()
        {
            const string ExpectedResult = "There is already a logged in user";
            this.tracker.RegisterUser("Gogo", "12345", "12345");
            this.tracker.LoginUser("Gogo", "12345");
            string resultView = this.tracker.RegisterUser("admin", "password", "password");
            Assert.AreEqual(ExpectedResult, resultView);
        }

        [TestMethod]
        public void TestRegisterUser_WithAlreadyTakenUsetname()
        {
            const string ExpectedResult = "A user with username admin already exists";
            this.tracker.RegisterUser("admin", "password", "password");
            this.tracker.LogoutUser();
            string resultView = this.tracker.RegisterUser("admin", "testa", "testa");
            Assert.AreEqual(ExpectedResult, resultView);
        }
    }
}
