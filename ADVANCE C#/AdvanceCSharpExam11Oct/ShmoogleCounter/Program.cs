namespace ShmoogleCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"(double|int)\s+([a-z][a-zA-Z]*)";
            Regex regex = new Regex(pattern);
            List<string> ints = new List<string>();
            List<string> doubles = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != "//END_OF_CODE")
            {
                var variables = regex.Matches(line);
                foreach (Match variable in variables)
                {
                    var type = variable.Groups[1].Value;
                    var name = variable.Groups[2].Value;
                    if (type == "double")
                    {
                        doubles.Add(name);
                    }
                    else
                    {
                        ints.Add(name);
                    }
                }
            }

            Console.WriteLine("Doubles: {0}", FormatOutput(doubles));
            Console.WriteLine("Ints: {0}", FormatOutput(ints));
        }

        private static string FormatOutput(ICollection<string> vars)
        {
            return vars.Count > 0 ? string.Join(", ", vars.OrderBy(v => v)) : "None";
        }
    }
}
