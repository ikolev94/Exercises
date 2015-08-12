namespace TravelAgency.Models
{
    using System;
    using System.Globalization;

    using TravelAgency.Enums;

    public abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(TicketType ticketType,string from,string to,DateTime dateAndTime, decimal price)
        {
            this.Type = ticketType;
            this.From = from;
            this.To = to;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public TicketType Type { get; private set; }

        public string From { get; private set; }

        public string To { get; private set; }

        public DateTime DateAndTime { get; private set; }
        
        public decimal Price { get; private set; }

        public abstract string UniqueKey { get; }

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
            return "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "; " + this.Type.ToString().ToLower() + "; "
                           + string.Format("{0:f2}", this.Price) + "]";
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