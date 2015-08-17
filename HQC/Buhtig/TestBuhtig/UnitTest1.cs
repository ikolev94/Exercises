namespace TestBuhtig
{
    using Buhtig_Issue_Tracker;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRegisterUser()
        {
            IssueTracker issueTracker = new IssueTracker();
            var message = issueTracker.RegisterUser("Admin", "12345", "12345");
            Assert.AreEqual("User Admin registered successfully", message);
        }

        [TestMethod]
        public void TestRegisterUser2()
        {
            IssueTracker issueTracker = new IssueTracker();
            var message = issueTracker.RegisterUser("Admin", "12345", "012345");
            Assert.AreEqual("The provided passwords do not match", message);
        }
    }
}
