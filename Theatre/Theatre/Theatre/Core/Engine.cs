namespace Theatre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Theatre.Exceptions;
    using Theatre.Interfaces;
    using Theatre.Models;

    public class Engine : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> allTheatres;

        public Engine()
        {
            this.allTheatres = new SortedDictionary<string, SortedSet<Performance>>();
        }

        public string ExecuteAddTheatreCommand(string theatre)
        {
            this.AddTheatre(theatre);
            return "Theatre added";
        }

        public string ExecuteAddPerformancesCommand(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            this.AddPerformance(theatre, performance, dateAndTime, duration, price);
            return "Performance added";
        }

        public string ExecutePrintPerformancesCommand(string theatre)
        {
            string commandResult;
            var performances = this.ListPerformances(theatre).Select(
                p =>
                {
                    string result1 = p.Date.ToString("dd.MM.yyyy HH:mm");
                    return string.Format("({0}, {1})", p.PerformanceName, result1);
                }).ToList();
            if (performances.Any())
            {
                commandResult = string.Join(", ", performances);
            }
            else
            {
                commandResult = "No performances";
            }

            return commandResult;
        }

        public string ExecutePrintAllPerformancesCommand()
        {
            var performances = this.ListAllPerformances().ToList();
            var sb = new StringBuilder();
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    string result1 = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat(
                        "({0}, {1}, {2})",
                        performances[i].PerformanceName,
                        performances[i].Theatre,
                        result1);
                }

                return sb.ToString();
            }

            return "No performances";
        }

        public void AddTheatre(string theatre)
        {
            if (this.allTheatres.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.allTheatres[theatre] = new SortedSet<Performance>();
        }

        public string ExecutePrintAllTheatresCommand()
        {
            if (this.ListTheatres().Any())
            {
                return string.Join(", ", this.ListTheatres());
            }
            else
            {
                return "No theatres";
            }
        }

        public IEnumerable<string> ListTheatres()
        {
            var teatres = this.allTheatres.Keys;
            return teatres;
        }

        public void AddPerformance(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            if (!this.allTheatres.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.allTheatres[theatre];

            var endOfPerformance = dateAndTime + duration;
            if (this.IsAvailableSlot(performances, dateAndTime, endOfPerformance))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performanceToAdd = new Performance(theatre, performance, dateAndTime, duration, price);
            performances.Add(performanceToAdd);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.allTheatres.Keys;

            var allPerformances = new List<Performance>();
            foreach (var theate in theatres)
            {
                var performances = this.allTheatres[theate];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.allTheatres.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            return this.allTheatres[theatreName];
        }

        private bool IsAvailableSlot(IEnumerable<Performance> performances, DateTime startTime, DateTime endTime)
        {
            foreach (var performance in performances)
            {
                var performanceStartDate = performance.Date;
                var performanceEndDate = performance.Date + performance.Duration;

                if ((performanceStartDate <= startTime && startTime <= performanceEndDate) ||
                    (performanceStartDate <= endTime && endTime <= performanceEndDate) ||
                    (startTime <= performanceStartDate && performanceStartDate <= endTime) ||
                    (startTime <= performanceEndDate && performanceEndDate <= endTime))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
