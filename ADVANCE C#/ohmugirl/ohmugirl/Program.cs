using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ohmugirl
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] specialSymbols = { '*', '+', '?', '[', ']', '{', '}', ',', '.', '^', '$', '<', '>', '\\', '/', '(', ')', '"' };
            string key = Console.ReadLine();
            var keyBuilder = KeyPatternMaker(key, specialSymbols);

            StringBuilder textBuilder = new StringBuilder();
            string text = Console.ReadLine();
            while (text != "END")
            {
                textBuilder.Append(text);
                text = Console.ReadLine();
            }
            MatchCollection match = Regex.Matches(textBuilder.ToString(), keyBuilder.ToString());
            foreach (Match match1 in match)
            {
                Console.Write(match1.Groups[1]);
            }



        }

        private static StringBuilder KeyPatternMaker(string key, char[] spec)
        {
            StringBuilder keyBuilder = new StringBuilder();
            if (spec.Contains(key[0]))
            {
                keyBuilder.Append("\\" + key[0]);
            }
            else
            {
                keyBuilder.Append(key[0]);
            }
            for (int i = 1; i < key.Length - 1; i++)
            {
                char tempSymbol = key[i];
                if (char.IsDigit(tempSymbol))
                {
                    keyBuilder.Append("\\d*");
                }
                else if (char.IsUpper(tempSymbol))
                {
                    keyBuilder.Append("[A-Z]*");
                }
                else if (char.IsLower(tempSymbol))
                {
                    keyBuilder.Append("[a-z]*");
                }
                else
                {
                    keyBuilder.Append("\\" + tempSymbol);
                }
            }
            if (spec.Contains(key[key.Length - 1]))
            {
                keyBuilder.Append("\\" + key[key.Length - 1]);
            }
            else
            {
                keyBuilder.Append(key[key.Length - 1]);
            }
            StringBuilder keyRightPattern = new StringBuilder(keyBuilder.ToString());
            keyBuilder.Append("(.{2,6})");
            keyBuilder.Append(keyRightPattern);
            return keyBuilder;
        }
    }
}
