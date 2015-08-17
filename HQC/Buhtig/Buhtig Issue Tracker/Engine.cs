namespace Buhtig_Issue_Tracker
{
    using System;

    using Buhtig_Issue_Tracker.Interfaces;

    public class Engine : IEngine
    {
        private readonly Dispatcher dispatcher;

        public Engine(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void Run()
        {
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var ep = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(ep);
                        Console.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
