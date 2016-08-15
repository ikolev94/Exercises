namespace LoggingSystem.Interfaces
{
    using Enums;

    public interface ILogger
    {
        IAppender Appender { get; }

        void Log(MessageType messageType, string message);
    }
}
