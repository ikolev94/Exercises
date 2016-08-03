namespace LoggingSystem.Interfaces
{
    using Enums;

    public interface IAppender
    {
        void Append(MessageType messageType, string message);
    }
}
