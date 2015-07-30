﻿namespace Theatre
{
    using System;
    using System.Collections.Generic;

    public interface IPerformanceDatabase
    {
        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddTheatre(string theatre);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<string> ListTheatres();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<Performance> ListAllPerformances();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
