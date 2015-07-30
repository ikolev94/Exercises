using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (input != "burp")
            {

                sb.Append(input);
                input = Console.ReadLine();
            }
            sb.Replace(@"\s+", " ");

            string pattern = @"([$%'&])([^$&%']+)\1";
            Regex reg = new Regex(pattern);
            MatchCollection match = reg.Matches(sb.ToString());

            foreach (Match porcii in match)
            {
                string result = porcii.Groups[2].Value;
                char first = porcii.Groups[1].Value[0];
                int toAdd = 0;
                switch (first)
                {
                    case '$':
                        toAdd = 1;
                        break;
                    case '%':
                        toAdd = 2;
                        break;
                    case '&':
                        toAdd = 3;
                        break;
                    case '\'':
                        toAdd = 4;
                        break;

                }
                StringBuilder sba = new StringBuilder();
                char[] resultToChar = new char[result.Length];
                for (int i = 0; i < result.Length; i++)
                {

                    if (i % 2 == 0)
                    {
                        resultToChar[i] = (char)(result[i] + toAdd);
                    }
                    else
                    {
                        resultToChar[i] = (char)(result[i] - toAdd);
                    }
                    sba.Append(resultToChar[i]);
                }
                
                Console.Write(sba+" ");
            }

        }
    }
}
