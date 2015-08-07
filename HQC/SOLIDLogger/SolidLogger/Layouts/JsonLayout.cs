namespace SolidLogger.Layouts
{
    using System;
    using System.Text;

    using SolidLogger.Interfaces;

    public class JsonLayout : ILayout
    {
        public string LayoutMaker(DateTime date, ReportLevel reportLevel, string message)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("{");
            output.AppendLine(string.Format("\"Message\" : \"{0}\"", message));
            output.AppendLine(string.Format("\"Report level\" : \"{0}\"", reportLevel));
            output.AppendLine(string.Format("\"Date\" : \"{0}\"", date));
            output.AppendLine("}");

            return output.ToString();
        }
    }
}
