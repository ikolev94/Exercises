namespace AnotherLoggingSystemConsumer
{
    using LoggingSystem;
    using LoggingSystem.Appenders;
    using LoggingSystem.Enums;
    using LoggingSystem.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            // txt log
            IAppender textAppender = new TextFileAppender(@"c:\temp\anotherLog.txt");
            ILogger logger = new Logger(textAppender);

            logger.Log(MessageType.Error, "test 123");
            logger.Log(MessageType.Info, "information 1 information 2");

            // xml log
            IAppender xmlAppender = new XmlAppender(@"c:\temp\anotherXmlLog.xml");
            ILogger xlogger = new Logger(xmlAppender);

            xlogger.Log(MessageType.Warning, "test 123 xml");
            xlogger.Log(MessageType.Info, "information xml");

            // console log 
            IAppender cAppender = new CustomAppender();
            ILogger cLogger = new Logger(cAppender);

            cLogger.Log(MessageType.Warning, "warning test");
        }
    }
}
