namespace BuhtigIssueTracker.Test
{
    using System;

    using BuhtigIssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetMyIssuesTest :Test
    {
        [TestMethod]
        public void TestGetMyIssues_WhitNoUser()
        {
            const string ExpectedResult = "There is no currently logged in user";
            string actualResult = this.tracker.GetMyIssues();
            Assert.AreEqual(ExpectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetMyIssues_WhitNoIssues()
        {
            const string ExpectedResult = "No issues";
            this.tracker.RegisterUser("admin", "password", "password");
            this.tracker.LoginUser("admin", "password");
            string actualResult = this.tracker.GetMyIssues();
            Assert.AreEqual(ExpectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetMyIssues_ShouldReturnOneIssue()
        {
            this.tracker.RegisterUser("admin", "password", "password");
            this.tracker.LoginUser("admin", "password");
            this.tracker.CreateIssue("issue", "test issue", IssuePriority.High, new[] { string.Empty });
            string actualResult = this.tracker.GetMyIssues();
            string[] actualResultParams = actualResult.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(4, actualResultParams.Length);
            Assert.AreEqual("issue", actualResultParams[0]);
            Assert.AreEqual("Priority: ***", actualResultParams[1]);
            Assert.AreEqual("test issue", actualResultParams[2]);
            Assert.AreEqual("Tags:", actualResultParams[3]);
        }
    }
}
