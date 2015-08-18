namespace BuhtigIssueTracker.Interfaces
{
    using BuhtigIssueTracker.Models;

    /// <summary>Countains methods for working whit an issue tracker system.</summary>
    public interface IIssueTracker
    {
        /// <summary>Registers a user in the database. </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmPassword">The confirm password.</param>
        /// <returns>In case of success, the action returns User (username) registered successfully
        /// If there is already a logged in user, the action returns There is already a logged in user
        /// If the two passwords do not match, the action returns The provided passwords do not match
        /// If the username is already taken, the action returns A user with username (username) already exists
        /// </returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// Logins a user in the application. After login, they become the currently active user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// In case of success, the action returns User (username) logged in successfully
        /// If there is already a logged in user, the action returns There is already a logged in user
        /// If there is no user with the provided username, the action returns A user with username (username) does not exist
        /// </returns>
        string LoginUser(string username, string password);

        /// <summary>Logs out the currently active user.</summary>
        /// <returns>In case of success, the action returns User (username) logged out successfully
        /// If there is no logged in user, the action returns There is no currently logged in user
        /// </returns>
        string LogoutUser();

        /// <summary>
        /// Creates a new issue. Assigns the current user as its author. Gives it an ID automatically.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="tags">The tags.</param>
        /// <returns>
        /// In case of success, the action returns Issue (id) created successfully
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// If the issue title is less than 3 symbols long, or if the issue description is less than 5 symbols long,
        /// the system throws an ArgumentException with an appropriate message.</exception>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>Removes an issue given by the specified ID.</summary>
        /// <param name="issueId">The issue id.</param>
        /// <returns>
        /// In case of success, the action returns Issue (id) removed
        /// If there is no logged in user, the action returns There is no currently logged in user
        /// If the issue ID is invalid, the action returns There is no issue with ID (id)
        /// If the issue does not belong to the currently logged in user, the action returns
        /// The issue with ID (id) does not belong to user (current_user_username) 
        /// </returns>
        string RemoveIssue(int issueId);

        /// <summary>Adds a comment to the issue given by the specified ID.</summary>
        /// <param name="issueId">The issue id.</param>
        /// <param name="text">The text.</param>
        /// <returns>
        /// In case of success, the action returns Comment added successfully to issue (id)
        /// If there is no logged in user, the action returns There is no currently logged in user
        /// If the issue ID is invalid, the action returns There is no issue with ID (id)
        /// </returns>
        /// <exception cref="System.ArgumentException ">
        /// If the text is less than 2 symbols long
        /// </exception>
        string AddComment(int issueId, string text);

        /// <summary>Returns the issues created by the currently active user.</summary>
        /// <returns>
        /// In case of success, the action returns the issues sorted by priority (in descending order) first,
        /// and by title (in alphabetical order) next.
        /// If there are no issues, the action returns No issues .
        /// If there is no logged in user, the action returns There is no currently logged in user.
        /// </returns>
        string GetMyIssues();

        /// <summary>
        /// Returns the comments created by the currently active user.
        /// </summary>
        /// <returns>
        /// In case of success, the action returns the comments sorted by time of adding to the application database. 
        /// If there are no comments, the action returns No comments
        /// If there is no logged in user, the action returns There is no currently logged in user
        /// </returns>
        string GetMyComments();

        /// <summary>
        /// Searches for issues containing one or more of the provided tags.
        /// </summary>
        /// <param name="tags">The tags.</param>
        /// <returns>
        /// In case of success, the action returns the issues sorted by priority (in descending order) first,
        /// and by title (in alphabetical order) next.
        /// 
        /// If there are no tags provided, the action returns There are no tags provided 
        /// If there are no matching issues, the action returns There are no issues matching the tags provided
        /// </returns>
        string SearchForIssues(string[] tags);
    }
}