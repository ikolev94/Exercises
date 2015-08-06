namespace SolidLogger.Layouts
{
    using System;

    using SolidLogger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string LayoutMaker(DateTime date, ReportLevel reportLevel, string message)
        {
            string output = string.Format("{0}-{1}-{2}", date, reportLevel, message);
            return output;
        }
    }
}
