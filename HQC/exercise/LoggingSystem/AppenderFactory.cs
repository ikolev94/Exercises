namespace LoggingSystem
{
    using System;
    using Appenders;
    using Interfaces;
    using Enums;

    public class AppenderFactory
    {
        public static IAppender CreateFileAppender(LoggingStore loggingStore, string path)
        {
            switch (loggingStore)
            {
                case LoggingStore.TextFile:
                    return new TextFileAppender(path);
                case LoggingStore.DB:
                    return new XmlAppender(path);
                default:
                    throw new NotSupportedException("Invalid appender type");
            }
        }
    }
}
