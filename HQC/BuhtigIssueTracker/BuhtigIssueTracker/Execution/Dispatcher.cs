namespace BuhtigIssueTracker.Execution
{
    using System;

    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;

    public class Dispatcher
    {
        private readonly IIssueTracker tracker;

        public Dispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }

        public Dispatcher()
            : this(new IssueTracker())
        {
        }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.tracker.RegisterUser(
                        endpoint.Parameters["username"], 
                        endpoint.Parameters["password"], 
                        endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.tracker.LoginUser(endpoint.Parameters["username"], endpoint.Parameters["password"]);
                case "CreateIssue":
                    return this.tracker.CreateIssue(
                        endpoint.Parameters["title"], 
                        endpoint.Parameters["description"], 
                        (IssuePriority)Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true), 
                        endpoint.Parameters["tags"].Split('|'));
                case "RemoveIssue":
                    return this.tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                case "LogoutUser":
                    return this.tracker.LogoutUser();
                case "AddComment":
                    return this.tracker.AddComment(int.Parse(endpoint.Parameters["id"]), endpoint.Parameters["text"]);
                case "MyIssues":
                    return this.tracker.GetMyIssues();
                case "MyComments":
                    return this.tracker.GetMyComments();
                case "Search":
                    return this.tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}