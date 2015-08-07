namespace SolidLogger.Interfaces
{
    using System;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(DateTime date, ReportLevel reportLevel, string message);
    }
}
