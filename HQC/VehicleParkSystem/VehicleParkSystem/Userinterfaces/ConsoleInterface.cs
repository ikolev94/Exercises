namespace VehicleParkSystem.Userinterfaces
{
    using System;

    using VehicleParkSystem.Iterfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
