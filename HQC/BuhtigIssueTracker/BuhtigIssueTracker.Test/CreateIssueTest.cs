namespace BuhtigIssueTracker.Test
{
    using System;

    using BuhtigIssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateIssueTest :Test
    {
        [TestMethod]
        public void TestCreateIssue_WhitNoLoggedinUser()
        {
            const string ExpectedResult = "There is no currently logged in user";
            string actualResult = this.tracker.CreateIssue("abcde", "this is issue", IssuePriority.High, new[] { "tag" });
            Assert.AreEqual(ExpectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateIssue_WhitInvalidIssueTitle()
        {
            this.tracker.RegisterUser("admin", "password", "password");
            this.tracker.LoginUser("admin", "password");
            this.tracker.CreateIssue("ab", "this is issue", IssuePriority.High, new[] { "tag" });
        }

        [TestMethod]
        public void TestCreateIssue_ShouldCreateIssue()
        {
            const string ExpectedResult = "Issue 1 created successfully";
            this.tracker.RegisterUser("admin", "password", "password");
            this.tracker.LoginUser("admin", "password");
            string actualResult = this.tracker.CreateIssue("abcde", "this is issue", IssuePriority.High, new[] { "tag" });
            Assert.AreEqual(ExpectedResult, actualResult);
        }
    }
}
