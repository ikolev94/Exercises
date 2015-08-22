namespace VehicleParkSystem
{
    using System;

    using VehicleParkSystem.Iterfaces;
    using VehicleParkSystem.Userinterfaces;

    internal class Engine : IEngine
    {
        private readonly CommandExecutor commandExecutor;

        private readonly IUserInterface userInterface;

        public Engine(CommandExecutor commandExecutor, IUserInterface userInterface)
        {
            this.userInterface = userInterface;
            this.commandExecutor = commandExecutor;
        }

        public Engine()
            : this(new CommandExecutor(), new ConsoleInterface())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.commandExecutor.Execute(command);
                        this.userInterface.WriteLine(commandResult);
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