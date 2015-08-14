namespace TravelAgency.Models
{
    using System;

    using TravelAgency.Enums;
    using TravelAgency.Interfaces;

    public abstract class Ticket : ITicket 
    {
        protected Ticket(TicketType ticketType, string from, string to, DateTime dateAndTime, decimal price)
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
                return string.Format("{0};{1}", this.From, this.To);
            }
        }

        public int CompareTo(Ticket otherTicket)
        {
            int compareToResult = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (compareToResult == 0)
            {
                compareToResult = this.Type.CompareTo(otherTicket.Type);
            }

            if (compareToResult == 0)
            {
                compareToResult = this.Price.CompareTo(otherTicket.Price);
            }

            return compareToResult;
        }

        public override string ToString()
        {
            return "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "; " + this.Type.ToString().ToLower() + "; "
                           + string.Format("{0:f2}", this.Price) + "]";
        }
    }
}