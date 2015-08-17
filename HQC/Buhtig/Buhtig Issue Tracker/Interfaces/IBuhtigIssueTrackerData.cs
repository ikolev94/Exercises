namespace Buhtig_Issue_Tracker.Interfaces
{
    using System.Collections.Generic;

    using Buhtig_Issue_Tracker.Models;

    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersByName { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IsusuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTags { get; }

        MultiDictionary<User, Comment> CommentsByUser { get; }
        
        int AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }
}