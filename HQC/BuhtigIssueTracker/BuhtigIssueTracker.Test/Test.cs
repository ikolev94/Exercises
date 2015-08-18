namespace BuhtigIssueTracker.Test
{
    using System.Globalization;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test
    {
        protected IssueTracker tracker { get; private set; }

        [TestInitialize]
        public void InitializeTests()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tracker = new IssueTracker();
        }
    }
}
