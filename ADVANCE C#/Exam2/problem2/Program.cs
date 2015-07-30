using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace problem2
{
    class Program
    {
        static void Main()
        {
            List<string> inputText = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string line = Console.ReadLine();
            while (line != "end")
            {
                try
                {
                    GetValue(line, inputText);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input parameters.");
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", inputText) + "]");
        }

        private static void GetValue(string line, List<string> inputText)
        {
            string[] comands = line.Split();
            switch (comands[0])
            {
                case "reverse":
                    int start = int.Parse(comands[2]);
                    if (start == inputText.Count)
                    {
                        throw new ArgumentException();
                    }
                    int lenght = int.Parse(comands[4]);
                    inputText.Reverse(start, lenght);
                    break;
                case "sort":
                    int startSort = int.Parse(comands[2]);
                    if (startSort == inputText.Count)
                    {
                        throw new ArgumentException();
                    }
                    int lenghtSort = int.Parse(comands[4]);
                    inputText.Sort(startSort, lenghtSort, StringComparer.InvariantCulture);
                    break;
                case "rollLeft":
                    rollRight(comands, inputText);
                    break;
                case "rollRight":
                    rollLeft(comands, inputText);
                    break;
            }
        }

        private static void rollLeft(string[] comands, List<string> inputText)
        {
            for (int i = 0; i < int.Parse(comands[1]); i++)
            {
                string temp = inputText.Last();
                inputText.Insert(0, temp);
                inputText.RemoveAt(inputText.Count - 1);
            }
        }

        private static void rollRight(string[] comands, List<string> inputText)
        {
            int times = int.Parse(comands[1])%inputText.Count;
            for (int i = 0; i < times; i++)
            {
                string temp = inputText.First();
                inputText.Add(temp);
                inputText.RemoveAt(0);
            }
        }
    }
}

