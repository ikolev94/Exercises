namespace TravelAgency.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TravelAgency.Enums;
    using TravelAgency.Interfaces;
    using TravelAgency.Models;

    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly MultiDictionary<string, Ticket> ticketsByFromToKey = new MultiDictionary<string, Ticket>(true);

        private readonly Dictionary<string, Ticket> ticketesByUniqueKey = new Dictionary<string, Ticket>();

        private readonly OrderedMultiDictionary<DateTime, Ticket> ticketsByDate = new OrderedMultiDictionary<DateTime, Ticket>(true);

        private int airTicketsCount;

        private int busTicketsCount;

        private int trainTicketsCount;

        public string FindTickets(string from, string to)
        {
            string fromToKey = string.Format("{0};{1}", from, to);
            if (this.ticketsByFromToKey.ContainsKey(fromToKey))
            {
                List<Ticket> ticketsFound = this.ticketsByFromToKey[fromToKey].ToList();

                string ticketsAsString = this.ReadTickets(ticketsFound);

                return ticketsAsString;
            }
            else
            {
                return "Not found";
            }
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDate.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = this.ReadTickets(ticketsFound);

                return ticketsAsString;
            }
            else
            {
                return "Not found";
            }
        }

        public int GetTicketsCount(TicketType type)
        {
            switch (type)
            {
                case TicketType.Air:
                    return this.airTicketsCount;
                case TicketType.Bus:
                    return this.busTicketsCount;
                default:
                    return this.trainTicketsCount;
            }
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateAndTime, decimal price)
        {
            AirTicket ticket = new AirTicket(from, to, dateAndTime, price, flightNumber, airline);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(null, null, default(DateTime), 0, flightNumber, null);

            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateAndTime, decimal regularPrice, decimal studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime, regularPrice, studentPrice);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateAndTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime, 0, 0);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            BusTicket ticket = new BusTicket(from, to, dateTime, price, travelCompany);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateAndTime)
        {
            BusTicket ticket = new BusTicket(from, to, dateAndTime, 0, travelCompany);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        public string ReadTickets(IEnumerable<Ticket> tickets)
        {
            return string.Join(" ", tickets.OrderBy(t => t));
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.ticketesByUniqueKey.ContainsKey(key))
            {
                return "Duplicate ticket";
            }
            else
            {
                this.ticketesByUniqueKey.Add(key, ticket);
                string fromToKey = ticket.FromToKey;

                this.ticketsByFromToKey.Add(fromToKey, ticket);
                this.ticketsByDate.Add(ticket.DateAndTime, ticket);
                return "Ticket added";
            }
        }

        private string DeleteTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.ticketesByUniqueKey.ContainsKey(key))
            {
                ticket = this.ticketesByUniqueKey[key];
                this.ticketesByUniqueKey.Remove(key);
                string fromToKey = ticket.FromToKey;

                this.ticketsByFromToKey.Remove(fromToKey, ticket);
                this.ticketsByDate.Remove(ticket.DateAndTime, ticket);
                return "Ticket deleted";
            }
            else
            {
                return "Ticket does not exist";
            }
        }
    }
}