namespace Buhtig_Issue_Tracker
{
    using System.Globalization;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var buhtigIssueTrackerData = new BuhtigIssueTrackerData();
            var issueTracker = new IssueTracker(buhtigIssueTrackerData);
            var dispatcher = new Dispatcher(issueTracker);
            var engine = new Engine(dispatcher);
            engine.Run();
        }
    }
}
