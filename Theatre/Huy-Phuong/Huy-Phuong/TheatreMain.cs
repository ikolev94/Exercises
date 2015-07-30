namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    // Do not modify the interface members
    // Moving the interface to separate namespace is allowed
    // Adding XML documentation is allowed
    // TODO: document this interface definition

    internal partial class TheatreMain
    {
        public static IPerformanceDatabase Engine = new Engine();

        protected static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == null || inputLine == "end")
                {
                    return;
                }

                if (inputLine != string.Empty)
                {
                    string[] commandArgs = inputLine.Split('(');
                    string[] test = inputLine.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    string commandName = commandArgs[0];
                    string commandResult;
                    try
                    {
                        switch (commandName)
                        {
                            case "AddTheatre":
                                string theatreNamee = test[1];
                                Engine.AddTheatre(theatreNamee);
                                commandResult = "Theatre added";
                                break;
                            case "PrintAllTheatres":
                                var theatres = Engine.ListTheatres();
                                if (theatres.Any())
                                {
                                    commandResult = string.Join(", ", theatres);
                                }
                                else
                                {
                                    commandResult = "No theatres";
                                }

                                break;
                            case "AddPerformance":
                               string[] chiHuyParts1 = inputLine.Split(
                                    new[] { '(', ',', ')' },
                                    StringSplitOptions.RemoveEmptyEntries);
                                 string[] chiHuyParams1 = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();

                               string[] chiHuyParams = chiHuyParams1;
                                string theatreName = chiHuyParams[0];
                                string performanceTitle = chiHuyParams[1];
                                DateTime result = DateTime.ParseExact(
                                    chiHuyParams[2],
                                    "dd.MM.yyyy HH:mm",
                                    CultureInfo.InvariantCulture);

                                DateTime startDateTime = result;
                                TimeSpan result2 = TimeSpan.Parse(chiHuyParams[3]);
                                TimeSpan duration = result2;
                                decimal result3 = decimal.Parse(chiHuyParams[4], CultureInfo.InvariantCulture);
                                decimal price = result3;

                                Engine.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                                commandResult = "Performance added";
                                break;
                            case "PrintAllPerformances":
                                commandResult = ExecutePrintAllPerformancesCommand();
                                break;
                            case "PrintPerformances":
                                chiHuyParts1 = inputLine.Split(
                                                           new[] { '(', ',', ')' },
                                                           StringSplitOptions.RemoveEmptyEntries);
                                chiHuyParams1 = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();

                                chiHuyParams = chiHuyParams1;
                                string theatre = chiHuyParams[0];

                                var performances = Engine.ListPerformances(theatre).Select(
                                    p =>
                                    {
                                        string result1 = p.Date.ToString("dd.MM.yyyy HH:mm");
                                        return string.Format("({0}, {1})", p.PerformanceName, result1);
                                    }).ToList();
                                if (performances.Any())
                                {
                                    commandResult = string.Join(", ", performances);
                                }
                                else
                                {
                                    commandResult = "No performances";
                                }

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
    }

}