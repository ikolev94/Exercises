namespace TravelAgency.Core
{
    using System;
    using System.Collections.Generic;

    using TravelAgency.Enums;
    using TravelAgency.Interfaces;
    using TravelAgency.Models;

    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly MultiDictionary<string, Ticket> Dict2 = new MultiDictionary<string, Ticket>(true);

        public int airTicketsCount = 0;

        public int busTicketsCount = 0;

        internal Dictionary<string, Ticket> Dict = new Dictionary<string, Ticket>();

        internal OrderedMultiDictionary<DateTime, Ticket> Dict3 = new OrderedMultiDictionary<DateTime, Ticket>(true);

        public int trainTicketsCount = 0;

        public string FindTickets(string from, string to)
        {
            string fromToKey = Ticket.CreateFromToKey(from, to);
            if (this.Dict2.ContainsKey(fromToKey))
            {
                List<Ticket> ticketsFound = new List<Ticket>();
                foreach (var t in this.Dict2.Values)
                {
                    if (t.FromToKey == fromToKey)
                    {
                        ticketsFound.Add(t);
                    }
                }

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
            var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;
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

        public string AddAirTicket(
            string flightNumber, 
            string from, 
            string to, 
            string airline, 
            DateTime dateTime, 
            decimal price)
        {
            return this.AddAirTicket(
                flightNumber, 
                from, 
                to, 
                airline, 
                dateTime.ToString("dd.MM.yyyy HH:mm"), 
                price.ToString());
        }

        string ITicketCatalog.DeleteAirTicket(string flightNumber)
        {
            return this.DeleteAirTicket(flightNumber);
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            return this.AddTrainTicket(
                from, 
                to, 
                dateTime.ToString("dd.MM.yyyy HH:mm"), 
                price.ToString(), 
                studentPrice.ToString());
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            return this.DeleteTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            return this.AddBusTiket(
                from, 
                to, 
                travelCompany, 
                dateTime.ToString("dd.MM.yyyy HH:mm"), 
                price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            return this.DeleteBusTicket(from, to, travelCompany, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Air)
            {
                return this.airTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }

        public int GetTicketsCount(string type)
        {
            if (type == "air")
            {
                return this.airTicketsCount;
            }

            if (type == "bus")
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }

        public string AddTicket(Ticket ticket)
        {
            string key = ticket.MunfaridKuleed;
            if (this.Dict.ContainsKey(key))
            {
                return "Duplicate ticket";
            }
            else
            {
                this.Dict.Add(key, ticket);
                string fromToKey = ticket.FromToKey;

                this.Dict2.Add(fromToKey, ticket);
                this.Dict3.Add(ticket.DateAndTime, ticket);
                return "Ticket added";
            }
        }

        public string DeleteTicket(Ticket ticket)
        {
            string key = ticket.MunfaridKuleed;
            if (this.Dict.ContainsKey(key))
            {
                ticket = this.Dict[key];
                this.Dict.Remove(key);
                string fromToKey = ticket.FromToKey;

                this.Dict2.Remove(fromToKey, ticket);
                this.Dict3.Remove(ticket.DateAndTime, ticket);
                return "Ticket deleted";
            }
            else
            {
                return "Ticket does not exist";
            }
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, string dateAndTime, string price)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dateAndTime, price);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(flightNumber);

            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, string dateAndTime, string regularPrice, string studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime, regularPrice, studentPrice);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, string dateAndTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTiket(string from, string to, string travelCompany, string dateAndTime, string price)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateAndTime, price);
            string key = ticket.MunfaridKuleed;
            string result;

            if (this.Dict.ContainsKey(key))
            {
                result = "Duplicate ticket";
            }
            else
            {
                this.Dict.Add(key, ticket);
                string fromToKey = ticket.FromToKey;

                this.Dict2.Add(fromToKey, ticket);
                this.Dict3.Add(ticket.DateAndTime, ticket);
                result = "Ticket added";
            }

            if (result.Contains("added"))
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, string dateAndTime)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateAndTime);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        public string ReadTickets(ICollection<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);

            sortedTickets.Sort();
            string result = string.Empty;

            for (int i = 0; i < sortedTickets.Count; i++)
            {
                Ticket ticket = sortedTickets[i];

                result += ticket.ToString();

                if (i < sortedTickets.Count - 1)
                {
                    result += " ";
                }
            }

            return result;
        }

        public string FindTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
        {
            DateTime startDateTime = Ticket.ParseDateTime(startDateTimeStr);

            DateTime endDateTime = Ticket.ParseDateTime(endDateTimeStr);

            string ticketsAsString = this.FindTicketsInInterval(startDateTime, endDateTime);
            return ticketsAsString;
        }

        public string FindTicketsInInterval2(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;

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
    }
}