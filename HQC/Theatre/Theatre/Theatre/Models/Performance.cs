namespace Theatre.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string performanceName, DateTime date, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.PerformanceName = performanceName;
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; private set; }

        public string PerformanceName { get; private set; }

        public DateTime Date { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int compareToResult = this.Date.CompareTo(otherPerformance.Date);
            return compareToResult;
        }

        public override string ToString()
        {
            string result = string.Format(
                "Performance(Theatre Name: {0}; Performance Title: {1}; Date: {2}, Duration: {3}, Price: {4})", 
                this.Theatre, 
                this.PerformanceName, 
                this.Date.ToString("dd.MM.yyyy HH:mm"), 
                this.Duration.ToString("hh':'mm"), 
                this.Price.ToString("f2"));
            return result;
        }
    }
}
