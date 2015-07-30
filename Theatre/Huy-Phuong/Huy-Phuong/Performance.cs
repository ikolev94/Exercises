namespace Theatre
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

        public string Theatre { get; protected internal set; }

        public string PerformanceName { get; private set; }

        public DateTime Date { get; set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int tmp = this.Date.CompareTo(otherPerformance.Date);
            return tmp;
        }

        public override string ToString()
        {
            string result = string.Format(
                "Performance(Tr32: {0}; Tr23: {1}; date: {2}, duration: {3}, price: {4})", 
                this.Theatre, 
                this.PerformanceName, 
                this.Date.ToString("dd.MM.yyyy HH:mm"), 
                this.Duration.ToString("hh':'mm"), 
                this.Price.ToString("f2"));
            return result;
        }
    }
}
