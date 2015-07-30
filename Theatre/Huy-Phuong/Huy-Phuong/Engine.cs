namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Theatre.Exceptions;

    public class Engine : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> sortedDictionaryStringSortedSetPerformance =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatre)
        {
            if (this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.sortedDictionaryStringSortedSetPerformance[theatre] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var t2 = this.sortedDictionaryStringSortedSetPerformance.Keys;
            return t2;
        }

        void IPerformanceDatabase.AddPerformance(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var ps = this.sortedDictionaryStringSortedSetPerformance[theatre];

            var endOfPerformance = dateAndTime + duration;
            if (kiemTra(ps, dateAndTime, endOfPerformance))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var p = new Performance(theatre, performance, dateAndTime, duration, price);
            ps.Add(p);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.sortedDictionaryStringSortedSetPerformance.Keys;

            var result2 = new List<Performance>();
            foreach (var t in theatres)
            {
                var performances = this.sortedDictionaryStringSortedSetPerformance[t];
                result2.AddRange(performances);
            }

            return result2;
        }

        IEnumerable<Performance> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var asfd = this.sortedDictionaryStringSortedSetPerformance[theatreName];
            return asfd;
        }

        protected internal static bool kiemTra(IEnumerable<Performance> performances, DateTime startTime, DateTime endTime)
        {
            foreach (var performance in performances)
            {
                var ss = performance.Date;

                var ee = performance.Date + performance.Duration;
                var kiemTra = (ss <= startTime && startTime <= ee) || (ss <= endTime && endTime <= ee) || (startTime <= ss && ss <= endTime)
                              || (startTime <= ee && ee <= endTime);
                if (kiemTra)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
