using System;
using System.Text;
using System.Text.RegularExpressions;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            string comands = @"(?<name>[A-Z][a-zA-Z]*)[^a-zA-Z+]*?(?<phone>\+?[0-9][0-9.() \-\/]*[0-9])";
            StringBuilder sb = new StringBuilder();
            while (line != "END")
            {
                sb.Append(line);
                line = Console.ReadLine();
            }
            Regex reg = new Regex(comands);
            var mach = reg.Matches(sb.ToString());
            if (mach.Count == 0)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }
            Console.Write("<ol>");
            foreach (Match match in mach)
            {
                string phone = Regex.Replace(match.Groups["phone"].Value, @"[^+0-9]+", string.Empty);

                Console.Write(
                    "<li><b>{0}:</b> {1}</li>",
                    match.Groups["name"],
                    phone);
            }

            Console.Write("</ol>");
        }

    }
}
