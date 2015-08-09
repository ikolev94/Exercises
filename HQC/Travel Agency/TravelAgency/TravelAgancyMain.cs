namespace TravelAgency
{
    using System;

    using TravelAgency.Core;

    public class TravelAgencyMain
    {
        private static void Main()
        {
            Engine engine = new Engine();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                string commandResult = engine.ExecuteCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}