using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingSystem;
using LoggingSystem.Enums;

namespace LoggingSystemConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "file")
            {
                Logger logger = new Logger(LoggingStore.TextFile, args[1]);
                logger.Log(MessageType.Error, "This is an error message");
                logger.Log(MessageType.Warning, "This is a warning message");
                logger.Log(MessageType.Info, "This is a info message");
            }

            if (args[0] == "db")
            {
                Logger logger = new Logger(LoggingStore.DB, args[1]);
                logger.Log(MessageType.Error, "This is an error message");
                logger.Log(MessageType.Warning, "This is a warning message");
                logger.Log(MessageType.Info, "This is a info message");
            }
        }
    }
}
