namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Theatre.Core;

    public class TheatreMain
    {
        private static readonly Engine TheatreEngine = new Engine();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            string inputLine = Console.ReadLine();
            while (inputLine == null || inputLine != "end")
            {
                if (!string.IsNullOrEmpty(inputLine))
                {
                    ProcessCommand(inputLine);
                }

                inputLine = Console.ReadLine();
            }
        }

        private static void ProcessCommand(string inputLine)
        {
            string[] commandArgs = inputLine.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];
            string commandResult;
            try
            {
                switch (commandName)
                {
                    case "AddTheatre":
                        string theatreToAdd = commandArgs[1].Trim();
                        commandResult = TheatreEngine.ExecuteAddTheatreCommand(theatreToAdd);
                        break;
                    case "ExecutePrintAllTheatresCommand":
                        commandResult = TheatreEngine.ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        string theatreName = commandArgs[1].Trim();
                        string performanceTitle = commandArgs[2].Trim();
                        DateTime startDateTime = DateTime.ParseExact(commandArgs[3].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                        TimeSpan duration = TimeSpan.Parse(commandArgs[4].Trim());
                        decimal price = decimal.Parse(commandArgs[5].Trim(), CultureInfo.InvariantCulture);

                        commandResult = TheatreEngine.ExecuteAddPerformancesCommand(
                            theatreName,
                            performanceTitle,
                            startDateTime,
                            duration,
                            price);
                        break;
                    case "PrintAllPerformances":
                        commandResult = TheatreEngine.ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        string theatre = commandArgs[1].Trim();

                        commandResult = TheatreEngine.ExecutePrintPerformancesCommand(theatre);
                        break;
                    default:
                        commandResult = "Invalid command!";
                        break;
                }
            }
            catch (ApplicationException ex)
            {
                commandResult = "Error: " + ex.Message;
            }

            Console.WriteLine(commandResult);
        }
    }
}