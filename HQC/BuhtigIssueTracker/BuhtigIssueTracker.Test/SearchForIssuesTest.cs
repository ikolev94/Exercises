namespace BuhtigIssueTracker.Test
{
    using System;

    using BuhtigIssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SearchForIssuesTest : Test
    {
        [TestMethod]
        public void TestSearchForIssues_WhitNoMatchingIssues()
        {
            const string ExpectedResult = "There are no issues matching the tags provided";
            string actualResult = this.tracker.SearchForIssues(new[] { "tags" });
            Assert.AreEqual(ExpectedResult, actualResult);
        }

        [TestMethod]
        public void TestSearchForIssues_WhitNoTagsProvided()
        {
            const string ExpectedResult = "There are no tags provided";
            string actualResult = this.tracker.SearchForIssues(new string[] { });
            Assert.AreEqual(ExpectedResult, actualResult);
        }

        [TestMethod]
        public void TestSearchForIssues_ShouldReturnOneIssue()
        {
            this.tracker.RegisterUser("admin", "password", "password");
            this.tracker.LoginUser("admin", "password");
            this.tracker.CreateIssue("Sparta", "This is", IssuePriority.High, new[] { "tag", "fun" });
            string actualResult = this.tracker.SearchForIssues(new[] { "tag" });
            var actualResultparams = actualResult.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual("Sparta", actualResultparams[0]);
            Assert.AreEqual("Priority: ***", actualResultparams[1]);
            Assert.AreEqual("This is", actualResultparams[2]);
            Assert.AreEqual("Tags: fun,tag", actualResultparams[3]);
        }
    }
}
