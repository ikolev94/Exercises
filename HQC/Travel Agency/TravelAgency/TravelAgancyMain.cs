namespace TravelAgency
{
    using System;

    using TravelAgency.Core;

    public class TravelAgencyMain
    {
        private static void Main()
        {
            Engine parwana = new Engine();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                string commandResult = parwana.AmalKamaan(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}