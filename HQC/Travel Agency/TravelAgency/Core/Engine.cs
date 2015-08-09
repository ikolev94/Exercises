namespace TravelAgency.Core
{
    using System;
    using System.Collections.Generic;

    using TravelAgency.Enums;
    using TravelAgency.Interfaces;
    using TravelAgency.Models;

    using Wintellect.PowerCollections;

    public class Engine : ITicketCatalog
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

                string ticketsAsString = ReadTickets(ticketsFound);

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
                string ticketsAsString = ReadTickets(ticketsFound);

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

        string ITicketCatalog.DeleteAirTicket(string parwaaz_number)
        {
            return this.DeleteAirTicket(parwaaz_number);
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

        public string AddBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime, decimal price)
        {
            return this.AddBusTiket(
                from, 
                to, 
                Sayahat_ki_Tanzeem, 
                dateTime.ToString("dd.MM.yyyy HH:mm"), 
                price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime)
        {
            return this.DeleteBusTicket(from, to, Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"));
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

        public string DeleteAirTicket(string parwaaz_number)
        {
            AirTicket ticket = new AirTicket(parwaaz_number);

            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, string dt, string pp, string studentpp)
        {
            TrainTicket ticket = new TrainTicket(from, to, dt, pp, studentpp);

            string result = this.AddTicket(ticket);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string from, string to, string dt)
        {
            TrainTicket ticket = new TrainTicket(from, to, dt);
            string result = this.DeleteTicket(ticket);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTiket(string from, string to, string Sayahat_ki_Tanzeem, string dt, string pp)
        {
            BusTicket ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt, pp);
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

        public string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, string dt)
        {
            BusTicket ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt);
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
                string ticketsAsString = ReadTickets(ticketsFound);
                return ticketsAsString;
            }
            else
            {
                return "Not found";
            }
        }

        public string ExecuteCommand(string line)
        {
            if (line == string.Empty)
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string command = line.Substring(0, firstSpaceIndex);
            string result = "Invalid command!";

            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            switch (command)
            {
                case "AddAir":
                   result = this.AddAirTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        parameters[4], 
                        parameters[5]);
                    break;
                case "DeleteAir":
                    result = this.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    result = this.AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteTrain":
                    result = this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;
                case "AddBus":
                    result = this.AddBusTiket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        parameters[4]);
                    break;
                case "DeleteBus":
                    result = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                    break;
                case "FindTickets":
                    result = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    result = this.FindTicketsInInterval(parameters[0], parameters[1]);
                    break;
            }

            return result;
        }
    }
}