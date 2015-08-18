namespace BuhtigIssueTracker.Execution
{
    using System;

    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.UserInterfaces;

    public class Engine : IEngine
    {
        private readonly Dispatcher dispatcher;

        private readonly IUserInterface userInterface;

        public Engine(Dispatcher dispatcher, IUserInterface userInterface)
        {
            this.dispatcher = dispatcher;
            this.userInterface = userInterface;
        }

        public Engine()
            : this(new Dispatcher(), new ConsoleInterface())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = this.userInterface.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        this.userInterface.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}