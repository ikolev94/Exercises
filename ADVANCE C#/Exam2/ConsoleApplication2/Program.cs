using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Darjavi> data = new Dictionary<string, Darjavi>();
            while (input != "report")
            {
                input = Regex.Replace(input, @"\s+", " ");
                string[] line = input.Split('|');

                

                string name = line[0].Trim();
                string country = line[1].Trim();
                if (!data.ContainsKey(country))
                {
                    data[country] = new Darjavi();
                    data[country].Name = new List<string>();
                    data[country].Wins = 0;

                }
                if (data[country].Name.Contains(name))
                {
                    data[country].Wins++;
                }
                else
                {
                    data[country].Wins++;
                    data[country].Name.Add(name);
                    data[country].numberOfPlayers++;

                }



                input = Console.ReadLine();
            }
            var sorted = data.OrderByDescending(p => p.Value.Wins);
            foreach (var pair in sorted)
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", pair.Key, pair.Value.Name.Count, pair.Value.Wins);
            }
        }

        class Darjavi
        {
            //public string conty { get; set; }
            public List<string> Name { get; set; }
            public int numberOfPlayers { get; set; }
            public int Wins { get; set; }
        }
    }
}
