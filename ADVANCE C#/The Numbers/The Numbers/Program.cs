using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace The_Numbers
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Regex reg = new Regex(@"\d+");
            MatchCollection match = reg.Matches(text);
            List<string> outpuList = new List<string>();
            foreach (Match matchindex in match)
            {
                StringBuilder sb = new StringBuilder();
                string tempInt = "0x" + int.Parse(matchindex.Value).ToString("X").PadLeft(4, '0');
                outpuList.Add(tempInt);
            }
            Console.WriteLine(string.Join("-", outpuList));
        }
    }
}
