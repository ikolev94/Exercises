namespace SolidLogger.Loggers
{
    using System;
    using System.Collections.Generic;

    using SolidLogger.Interfaces;

    public class Logger : ILogger
    {
        private readonly IEnumerable<IAppender> appenders;

        public Logger(params IAppender[] appendersParams)
        {
            this.appenders = appendersParams;
        }

        public void Info(string message)
        {
            this.Log(ReportLevel.Info, message);
        }

        public void Warning(string message)
        {
            this.Log(ReportLevel.Warnimg, message);
        }

        public void Error(string message)
        {
            this.Log(ReportLevel.Error, message);
        }

        public void Critical(string message)
        {
            this.Log(ReportLevel.Critical, message);
        }

        public void Fatal(string message)
        {
            this.Log(ReportLevel.Fatal, message);
        }

        private void Log(ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                var date = DateTime.Now;
                appender.Append(date, reportLevel, message);
            }
        }
    }
}
