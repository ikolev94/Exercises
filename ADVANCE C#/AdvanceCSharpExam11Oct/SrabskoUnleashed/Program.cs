namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string line;
            Regex regex = new Regex(@"^(([a-zA-Z]+\s*){1,3}) @(([a-zA-Z]+\s*){1,3}) (\d+) (\d+)");
            var singersByPlaces = new Dictionary<string, Dictionary<string, int>>();
            while ((line = Console.ReadLine()) != "End")
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    string singer = match.Groups[1].Value;
                    string place = match.Groups[3].Value;
                    int ticketsPrice = int.Parse(match.Groups[5].Value);
                    int ticketsCount = int.Parse(match.Groups[6].Value);
                    if (!singersByPlaces.ContainsKey(place))
                    {
                        singersByPlaces[place] = new Dictionary<string, int>();
                    }

                    if (!singersByPlaces[place].ContainsKey(singer))
                    {
                        singersByPlaces[place][singer] = 0;
                    }

                    singersByPlaces[place][singer] += ticketsCount * ticketsPrice;
                }
            }

            foreach (var singersByPlace in singersByPlaces)
            {
                Console.WriteLine(singersByPlace.Key);
                foreach (var singers in singersByPlaces[singersByPlace.Key].OrderByDescending(s => s.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singers.Key, singers.Value);
                }
            }
        }
    }
}
