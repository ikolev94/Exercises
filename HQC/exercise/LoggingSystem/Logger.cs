namespace LoggingSystem
{
    using System;
    using Interfaces;
    using Enums;

    public class Logger : ILogger
    {
        private IAppender _appender;

        public Logger(LoggingStore store, string configuration)
        {
            this.Appender = AppenderFactory.CreateFileAppender(store, configuration);
        }

        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        public IAppender Appender
        {
            get
            {
                return this._appender;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Invalid Appender");
                }

                this._appender = value;
            }
        }

        public void Log(MessageType messageType, string message)
        {
            this.Appender.Append(messageType, message);
        }

    }
}
