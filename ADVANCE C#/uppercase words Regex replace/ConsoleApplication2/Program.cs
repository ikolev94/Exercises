using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication2
{
    class Program
    {
        private static void Main()
        {
            string text = String.Empty;
            Regex reg = new Regex(@"(?<![a-zA-z])[A-Z]+(?![a-zA-Z])");
            List<string> output = new List<string>();
            while ((text = Console.ReadLine()) != "END")
            {
                MatchCollection matchesOnTheLine = reg.Matches(text);
                int indexBonus = 0;
                foreach (Match uperWord in matchesOnTheLine)
                {
                    string word = uperWord.Value;
                    string revece = revercWord(uperWord);
                    if (revece == word)
                    {
                        revece = Doubeled(revece);
                    }
                    int index = uperWord.Index;
                    text = text.Remove(uperWord.Index + indexBonus, word.Length);
                    text = text.Insert(uperWord.Index + indexBonus, revece);
                    if (word.Length != revece.Length)
                    {
                        indexBonus += revece.Length - word.Length;
                    }
                }
                output.Add(text);
            }

            foreach (var line in output)
            {
                Console.WriteLine(SecurityElement.Escape(line));
            }

        }

        private static string Doubeled(string revece)
        {
            StringBuilder doubleBuilder = new StringBuilder();
            for (int i = 0; i < revece.Length; i++)
            {
                doubleBuilder.Append(new string(revece[i], 2));
            }
            return doubleBuilder.ToString();
        }

        private static string revercWord(Match uperWord)
        {
            StringBuilder sb = new StringBuilder();
            string temp = uperWord.Value;
            for (int i = uperWord.Value.Length - 1; i >= 0; i--)
            {
                sb.Append(uperWord.Value[i]);
            }
            return sb.ToString();
        }
    }


}
