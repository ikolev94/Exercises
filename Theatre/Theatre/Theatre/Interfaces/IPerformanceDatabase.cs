namespace Theatre.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Theatre.Models;

    /// <summary>The PerformanceDatabase interface.</summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Add theatre.
        /// </summary>
        /// <param name="theatre">Name of the theatre.</param>
        void AddTheatre(string theatre);

        /// <summary>
        /// Return all theatres
        /// </summary>
        /// <returns>All theatres</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>Add performance.</summary>
        /// <param name="theatreName">theatre name.</param>
        /// <param name="performanceTitle">performance title.</param>
        /// <param name="startDateTime">start date time.</param>
        /// <param name="duration">duration.</param>
        /// <param name="price">price.</param>
        void AddPerformance(
            string theatreName, 
            string performanceTitle, 
            DateTime startDateTime, 
            TimeSpan duration, 
            decimal price);

        /// <summary>
        /// Return all performances.
        /// </summary>
        /// <returns>All performances</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Reaturn the performances for given name.
        /// </summary>
        /// <param name="theatreName">Theatre name.</param>
        /// <returns></returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}