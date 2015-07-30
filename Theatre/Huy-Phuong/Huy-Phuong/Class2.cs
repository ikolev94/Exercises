namespace Theatre
{
    using System.Linq;
    using System.Text;

    internal partial class TheatreMain
    {
        protected internal static string ExecutePrintAllPerformancesCommand()
        {
            var performances = Engine.ListAllPerformances().ToList();
            var sb = new StringBuilder();
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {

                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    string result1 = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat("({0}, {1}, {2})", performances[i].PerformanceName
                        , performances[i].Theatre, result1);
                }

                return sb.ToString();
            }

            return "No performances";
        }
    }
}