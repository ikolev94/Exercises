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
            // Do not toch! It work!!! I spend 10 hours of fix buggy here
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
            string parwaaz_number, 
            string from, 
            string to, 
            string airline, 
            DateTime dateTime, 
            decimal price)
        {
            return this.AddAirTicket(
                parwaaz_number, 
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
            return this.basKaTicketKaIzafah(
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

        public string AddDeleteTicket(Ticket ticket, bool isAdd)
        {
            if (isAdd)
            {
                string key = ticket.MunfaridKuleed;
                if (this.Dict.ContainsKey(key))
                {
                    return "Duplicated ticket";
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
            else
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
        }

        public string AddAirTicket(string parwaaz_number, string from, string to, string airline, string dt, string pp)
        {
            AirTicket ticket = new AirTicket(parwaaz_number, from, to, airline, dt, pp);

            string result = this.AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                this.airTicketsCount++;
            }

            return result;
        }

        protected string DeleteAirTicket(string parwaaz_number)
        {
            AirTicket ticket = new AirTicket(parwaaz_number);

            string result = this.AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, string dt, string pp, string studentpp)
        {
            TrainTicket ticket = new TrainTicket(from, to, dt, pp, studentpp);

            string result = this.AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        private string DeleteTrainTicket(string from, string to, string dt)
        {
            TrainTicket ticket = new TrainTicket(from, to, dt);
            string result = this.AddDeleteTicket(ticket, false);

            if (result.Contains("deleted"))
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        protected string basKaTicketKaIzafah(string from, string to, string Sayahat_ki_Tanzeem, string dt, string pp)
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

        private string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, string dt)
        {
            BusTicket ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt);
            string result = this.AddDeleteTicket(ticket, false);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        internal static string ReadTickets(ICollection<Ticket> tickets)
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
                    result += ",  ";
                }
            }

            return result;
        }

        public string findTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
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

        internal string AmalKamaan(string line)
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

            string cd = line.Substring(0, firstSpaceIndex);
            string cd2 = "Invalid command!";
            switch (cd)
            {
                case "AddAir":
                    string allParameters = line.Substring(firstSpaceIndex + 1);
                    string[] parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.AddAirTicket(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        parameters[4], 
                        parameters[5]);
                    break;
                case "DeleteAir":

                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;
                case "DeleteTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;
                case "AddBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.basKaTicketKaIzafah(
                        parameters[0], 
                        parameters[1], 
                        parameters[2], 
                        parameters[3], 
                        parameters[4]);
                    break;
                case "DeleteBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                    break;
                case "FindTickets":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    cd2 = this.findTicketsInInterval(parameters[0], parameters[1]);
                    break;
            }

            return cd2;
        }
    }
}