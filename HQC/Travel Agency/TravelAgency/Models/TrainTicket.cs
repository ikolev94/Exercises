namespace TravelAgency.Models
{
    using System;

    using TravelAgency.Enums;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal studentPrice)
            : base(TicketType.Train, from, to, dateAndTime, price)
        {
            this.StudentPrice = studentPrice;
        }

        public decimal StudentPrice { get; set; }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}