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
            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string command = line.Substring(0, firstSpaceIndex);
            string result = "Invalid command!";

            var parameters = InputHandler(line, firstSpaceIndex);

            switch (command)
            {
                case "AddAir":
                    result = this.ProcessAddAirCommand(parameters);
                    break;
                case "DeleteAir":
                    result = this.ProcessDeleteAirCommand(parameters);
                    break;
                case "AddTrain":
                    result = this.ProcessAddTrainCommand(parameters);
                    break;
                case "DeleteTrain":
                    result = this.ProcessDeleteTrainCommand(parameters);
                    break;
                case "AddBus":
                    result = this.ProcessAddBudCommand(parameters);
                    break;
                case "DeleteBus":
                    result = this.ProcessDeleteBusCommand(parameters);
                    break;
                case "FindTickets":
                    result = this.ProcessFindTicketsCommand(parameters);
                    break;
                case "FindTicketsInInterval":
                    result = this.ProcessFindTicketsInIntervalCommand(parameters);
                    break;
            }

            return result;
        }

        private static string[] InputHandler(string line, int firstSpaceIndex)
        {
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            return parameters;
        }

        private string ProcessFindTicketsInIntervalCommand(string[] parameters)
        {
            var findTicketStart = DateTime.ParseExact(parameters[0], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var findTicketEnd = DateTime.ParseExact(parameters[1], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            string result = this.ticketCatalog.FindTicketsInInterval(findTicketStart, findTicketEnd);
            return result;
        }

        private string ProcessFindTicketsCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            var result = this.ticketCatalog.FindTickets(@from, to);
            return result;
        }

        private string ProcessDeleteBusCommand(string[] parameters)
        {
            var deleteBusDateTime = DateTime.ParseExact(parameters[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            string result = this.ticketCatalog.DeleteBusTicket(parameters[0], parameters[1], parameters[2], deleteBusDateTime);
            return result;
        }

        private string ProcessAddBudCommand(string[] parameters)
        {
            var addBusDateTime = DateTime.ParseExact(parameters[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var addBusPrice = decimal.Parse(parameters[4]);
            string result = this.ticketCatalog.AddBusTicket(parameters[0], parameters[1], parameters[2], addBusDateTime, addBusPrice);
            return result;
        }

        private string ProcessDeleteTrainCommand(string[] parameters)
        {
            var deleteTrainDateTime = DateTime.ParseExact(parameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var result = this.ticketCatalog.DeleteTrainTicket(parameters[0], parameters[1], deleteTrainDateTime);
            return result;
        }

        private string ProcessAddTrainCommand(string[] parameters)
        {
            var trainDateTime = DateTime.ParseExact(parameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var price = decimal.Parse(parameters[3]);
            var studentPrice = decimal.Parse(parameters[4]);
            var result = this.ticketCatalog.AddTrainTicket(parameters[0], parameters[1], trainDateTime, price, studentPrice);
            return result;
        }

        private string ProcessDeleteAirCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            var result = this.ticketCatalog.DeleteAirTicket(flightNumber);
            return result;
        }

        private string ProcessAddAirCommand(string[] parameters)
        {
            var flightDateTime = DateTime.ParseExact(parameters[4], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var flightPrice = decimal.Parse(parameters[5]);
            string result = this.ticketCatalog.AddAirTicket(
                 parameters[0],
                 parameters[1],
                 parameters[2],
                 parameters[3],
                 flightDateTime,
                 flightPrice);
            return result;
        }
    }
}
