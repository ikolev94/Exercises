namespace SolidLogger.Interfaces
{
    public interface ILogger
    {
        void Info(string message);

        void Warning(string message);

        void Error(string message);

        void Critical(string message);

        void Fatal(string message);
    }
}
