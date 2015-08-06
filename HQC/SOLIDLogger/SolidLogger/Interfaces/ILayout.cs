namespace SolidLogger.Interfaces
{
    using System;

    public interface ILayout
    {
        string LayoutMaker(DateTime date, ReportLevel reportLevel, string message);
    }
}
