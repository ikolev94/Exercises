namespace BuhtigIssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BuhtigIssueTracker.Data;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;

    public class IssueTracker : IIssueTracker
    {
        private readonly IBuhtigIssueTrackerData data;

        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.data = data;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            if (this.data.UsersByName.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.data.UsersByName.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (!this.data.UsersByName.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.data.UsersByName[username];
            if (user.PasswortHash != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.data.CurrentUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            string username = this.data.CurrentUser.Username;
            this.data.CurrentUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            this.data.AddIssue(issue);

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.data.IssuesById[issueId];
            if (!this.data.IssueByUsername[this.data.CurrentUser.Username].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.data.CurrentUser.Username);
            }

            this.data.RemoveIssue(issue);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int intValue, string stringValue)
        {
            if (this.data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.data.IssuesById.ContainsKey(intValue))
            {
                return string.Format("There is no issue with ID {0}", intValue);
            }

            var issue = this.data.IssuesById[intValue];
            var comment = new Comment(this.data.CurrentUser, stringValue);
            issue.AddComment(comment);
            this.data.CommentsByUsername[this.data.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issues = this.data.IssueByUsername[this.data.CurrentUser.Username];
            if (!issues.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (this.data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var comments = this.data.CommentsByUsername[this.data.CurrentUser];
            if (!comments.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, comments.Select(c => c.ToString()));
        }
        
        public string SearchForIssues(string[] strings)
        {
            if (strings.Length <= 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var t in strings)
            {
                issues.AddRange(this.data.IssuesByTag[t]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            return string.Join(
                Environment.NewLine,
                issues.Distinct().OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(x => x.ToString()));
        }
    }
}