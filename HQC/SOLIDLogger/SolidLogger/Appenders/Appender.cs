namespace SolidLogger.Appenders
{
    using System;

    using SolidLogger.Exceptions;
    using SolidLogger.Interfaces;

    public abstract class Appender : IAppender
    {
        private readonly ReportLevel defaultReportLevel;

        private ILayout layout;
        
        protected Appender(ILayout layout)
        {
            this.defaultReportLevel = ReportLevel.Info;
            this.Layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }

            set
            {
                if (value == null)
                {
                    throw new LayoutNullException("Layout cannot be null");
                }

                this.layout = value;
            }
        }

        public void Append(DateTime date, ReportLevel reportLevel, string message)
        {
            if (this.defaultReportLevel <= reportLevel)
            {
                this.AppendExecuter(date, reportLevel, message);
            }
        }

        protected abstract void AppendExecuter(DateTime date, ReportLevel reportLevel, string message);
    }
}
