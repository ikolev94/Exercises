namespace TravelAgency.Models
{
    using System;

    using TravelAgency.Enums;

    public class AirTicket : Ticket
    {
        public AirTicket(string from, string to, DateTime dateAndTime, decimal price, string flightNumber, string airline)
            : base(TicketType.Air, from, to, dateAndTime, price)
        {
            this.Airline = airline;
            this.FlightNumber = flightNumber;
        }

        public string Airline { get; private set; }

        public string FlightNumber { get; private set; }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.FlightNumber;
            }
        }
    }
}