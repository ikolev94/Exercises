using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biggest_Table_Row
{
    class Program
    {
        private const string pattern = @"(?<=<td>)([A-Za-z]+).*?([-?\d+.\d+]+).*?([-?\d+.\d+]+).*?([-?\d+.\d+]+)";

        static void Main(string[] args)
        {
            string topTown = String.Empty;
            double maxSum = double.MinValue;
            Dictionary<string,List<string>>data = new Dictionary<string, List<string>>();
            Regex reg = new Regex(pattern);
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "</table>")
            {
                
                Match match = reg.Match(input);
                if (match.Length == 0)
                {
                    continue;
                }
                double sum = 0;
                string town = match.Groups[1].Value;
                double number;
                string value = match.Groups[2].Value;
                bool isNumber = double.TryParse(value, out number);
                if (isNumber)
                {
                    sum += number;
                   
                }
                double numberr;
                string valuee = match.Groups[3].Value;
                bool isNumberr = double.TryParse(value, out numberr);
                if (isNumberr)
                {
                    sum += numberr;

                }
                double numberrr;
                string valueee = match.Groups[4].Value;
                bool isNumberrr = double.TryParse(value, out numberrr);
                if (isNumberr)
                {
                    sum += numberr;

                }
                //string town = match.Groups[1].Value;
                
                

                if (sum > maxSum)
                {
                    maxSum = sum;
                    topTown = town;
                    List<string> sums = SumMaker(match,maxSum);
                   data.Add(topTown,sums);

                }
            }
            Console.WriteLine("{0} = {1}",maxSum,string.Join(" + ",data[topTown]));
        }

        private static List<string> SumMaker(Match match,double maxSum)
        {
            List<string>temp = new List<string>();
            if (match.Groups[2].Value!="-")
            {
                temp.Add(match.Groups[2].Value);
            }
            if (match.Groups[3].Value!="-")
            {
                temp.Add(match.Groups[3].Value);
            }
            if (match.Groups[2].Value!="-")
            {
                temp.Add(match.Groups[4].Value);
            }
            return temp;

        }

    }
}
