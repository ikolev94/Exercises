namespace Buhtig_Issue_Tracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Buhtig_Issue_Tracker.Enums;
    using Buhtig_Issue_Tracker.Interfaces;
    using Buhtig_Issue_Tracker.Models;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        private BuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            if (this.Data.UsersByName.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.UsersByName.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (!this.Data.UsersByName.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.UsersByName[username];
            if (user.PasswortHash != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Data.CurrentUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            string username = this.Data.CurrentUser.UserName;
            this.Data.CurrentUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings)
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issue = new Issue(title, description, priority, strings.Distinct().ToList());
            int issueId = this.Data.AddIssue(issue);

            return string.Format("Issue {0} created successfully", issueId);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IsusuesByUsername[this.Data.CurrentUser.UserName]
                     .Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.Data.CurrentUser.UserName);
            }

            this.Data.RemoveIssue(issue);
            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int intValue, string text)
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Data.IssuesById.ContainsKey(intValue))
            {
                return string.Format("There is no issue with ID {0}", intValue);
            }

            var issue = this.Data.IssuesById[intValue];
            var comment = new Comment(this.Data.CurrentUser, text);
            issue.AddComment(comment);
            this.Data.CommentsByUser[this.Data.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issues =
                this.Data.IsusuesByUsername[this.Data.CurrentUser.UserName];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(x => x.ToString()));
        }

        public string GetMyComments()
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var comments = this.Data.CommentsByUser[this.Data.CurrentUser]
                .Select(i => i.ToString());
            var enumerable = comments as string[] ?? comments.ToArray();
            if (!enumerable.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, enumerable);
        }

        public string SearchForIssues(string[] strings)
        {
            if (strings.Length < 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var tag in strings)
            {
                issues.AddRange(this.Data.IssuesByTags[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            return string.Join(
                Environment.NewLine,
                issues.Distinct().OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(o => o.ToString()));
        }
    }
}