namespace TravelAgency.Core
{
    using System;
    using System.Globalization;

    using TravelAgency.Interfaces;

    public class Engine
    {
        private readonly ITicketCatalog ticketCatalog;

        public Engine(ITicketCatalog ticketCatalog)
        {
            this.ticketCatalog = ticketCatalog;
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
                    var flightDateTime = DateTime.ParseExact(parameters[4], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    var flightPrice = decimal.Parse(parameters[5]);
                    result = this.ticketCatalog.AddAirTicket(
                         parameters[0],
                         parameters[1],
                         parameters[2],
                         parameters[3],
                         flightDateTime,
                         flightPrice);
                    break;
                case "DeleteAir":
                    result = this.ticketCatalog.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    var trainDateTime = DateTime.ParseExact(parameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    var price = decimal.Parse(parameters[3]);
                    var studentPrice = decimal.Parse(parameters[4]);
                    result = this.ticketCatalog.AddTrainTicket(parameters[0], parameters[1], trainDateTime, price, studentPrice);
                    break;
                case "DeleteTrain":
                    var deleteTrainDateTime = DateTime.ParseExact(parameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    result = this.ticketCatalog.DeleteTrainTicket(parameters[0], parameters[1], deleteTrainDateTime);
                    break;
                case "AddBus":
                    var addBusDateTime = DateTime.ParseExact(parameters[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    var addBusPrice = decimal.Parse(parameters[4]);
                    result = this.ticketCatalog.AddBusTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        addBusDateTime,
                        addBusPrice);
                    break;
                case "DeleteBus":
                    var deleteBusDateTime = DateTime.ParseExact(parameters[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    result = this.ticketCatalog.DeleteBusTicket(parameters[0], parameters[1], parameters[2], deleteBusDateTime);
                    break;
                case "FindTickets":
                    result = this.ticketCatalog.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    var findTicketStart = DateTime.ParseExact(parameters[0], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    var findTicketEnd = DateTime.ParseExact(parameters[1], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    result = this.ticketCatalog.FindTicketsInInterval(findTicketStart, findTicketEnd);
                    break;
            }

            return result;
        }
    }
}
