namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;

    using BuhtigIssueTracker.Models;

    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersByName { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssueByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> CommentsByUsername { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}