namespace Buhtig_Issue_Tracker
{
    using System.Collections.Generic;

    using Buhtig_Issue_Tracker.Interfaces;
    using Buhtig_Issue_Tracker.Models;

    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public BuhtigIssueTrackerData()
        {
            this.NextIssueId = 1;
            this.UsersByName = new Dictionary<string, User>();

            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IsusuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTags = new MultiDictionary<string, Issue>(true);
            this.CommentsByUser = new MultiDictionary<User, Comment>(true);
        }

        public int NextIssueId { get; set; }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersByName { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IsusuesByUsername { get; set; }

        public MultiDictionary<string, Issue> IssuesByTags { get; set; }

        public MultiDictionary<User, Comment> CommentsByUser { get; set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.NextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.NextIssueId++;
            this.IsusuesByUsername[this.CurrentUser.UserName].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTags[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IsusuesByUsername[this.CurrentUser.UserName].Remove(
                issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTags[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}
