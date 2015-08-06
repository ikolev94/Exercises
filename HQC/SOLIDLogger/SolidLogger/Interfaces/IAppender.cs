namespace SolidLogger.Interfaces
{
    using System;

    public interface IAppender
    {
        void Append(DateTime date, ReportLevel reportLevel, string message);
    }
}
