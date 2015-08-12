namespace TravelAgency
{
    using System;

    using TravelAgency.Core;

    public class TravelAgencyMain
    {
        private static readonly TicketCatalog TicketCatalog = new TicketCatalog();
        private static readonly Engine Engine = new Engine(TicketCatalog);

        public static void Main()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (!string.IsNullOrEmpty(line))
                {
                    line = line.Trim();
                    string commandResult = Engine.ExecuteCommand(line);
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}