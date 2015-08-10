namespace TravelAgency.Models
{
    using System;
    using System.Globalization;

    public abstract class Ticket : IComparable<Ticket>
    {
        public abstract string Type { get; }

        public string From { get; set; }

        public string To { get; set; }

        public string Company { get; set; }

        public DateTime DateAndTime { get; set; }
        
        public decimal Price { get; set; }

        public decimal SpecialPrice { get; set; }

        public abstract string MunfaridKuleed { get; }

        public string FromToKey
        {
            get
            {
                return CreateFromToKey(this.From, this.To);
            }
        }

        public int CompareTo(Ticket otherTicket)
        {
            int nateeja = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (nateeja == 0)
            {
                nateeja = this.Type.CompareTo(otherTicket.Type);
            }

            if (nateeja == 0)
            {
                nateeja = this.Price.CompareTo(otherTicket.Price);
            }

            return nateeja;
        }

        public override string ToString()
        {
            string input = "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "; " + this.Type + "; "
                           + string.Format("{0:f2}", this.Price) + "]";
            return input;
        }

        public static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        public static DateTime ParseDateTime(string dt)
        {
            DateTime result = DateTime.ParseExact(dt, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }
    }
}