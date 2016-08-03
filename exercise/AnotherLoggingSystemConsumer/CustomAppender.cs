namespace AnotherLoggingSystemConsumer
{
    using System;
    using LoggingSystem.Enums;
    using LoggingSystem.Interfaces;

    public class CustomAppender : IAppender
    {
        public void Append(MessageType messageType, string message)
        {
            Console.WriteLine($"{messageType} --> {message}");
        }
    }
}
