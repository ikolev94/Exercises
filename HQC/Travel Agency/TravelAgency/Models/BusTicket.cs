namespace TravelAgency.Models
{
    using System;

    using TravelAgency.Enums;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, DateTime dateAndTime, decimal price, string company)
            : base(TicketType.Bus, from, to, dateAndTime, price)
        {
            this.Company = company;
        }

        public string Company { get; private set; }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}