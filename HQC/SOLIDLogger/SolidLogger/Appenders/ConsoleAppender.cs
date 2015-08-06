namespace SolidLogger.Appenders
{
    using System;

    using SolidLogger.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        protected override void AppendExecuter(DateTime date, ReportLevel reportLevel, string message)
        {
            string output = this.Layout.LayoutMaker(date, reportLevel, message);
            Console.WriteLine(output);
        }
    }
}
