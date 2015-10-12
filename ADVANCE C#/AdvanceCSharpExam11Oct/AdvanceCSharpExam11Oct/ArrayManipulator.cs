namespace AdvanceCSharpExam11Oct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "exchange":
                        numbers = Exchange(int.Parse(commandArgs[1]), numbers);
                        break;
                    case "min":
                        int indexOfMin = FindMin(commandArgs[1], numbers);
                        Console.WriteLine(indexOfMin > 0 ? indexOfMin + string.Empty : "No matches");
                        break;
                }

                foreach (int number in numbers)
                {
                    Console.Write(" " + number);
                }
            }
        }

        private static int FindMin(string evenOrOdd, int[] numbers)
        {
            bool isOdd = evenOrOdd == "odd";
            int min = int.MaxValue;
            int index = -1;
            if (isOdd)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (min >= numbers[i] && numbers[i] % 2 == 1)
                    {
                        min = numbers[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (min >= numbers[i] && numbers[i] % 2 == 0)
                    {
                        min = numbers[i];
                        index = i;
                    }
                }
            }
            return index;
        }

        private static int[] Exchange(int index, int[] numbers)
        {
            if (index > numbers.Length)
            {
                Console.WriteLine("Invalid index");
            }

            var left = numbers.Skip(index + 1).ToList();
            for (int i = 0; i < index + 1; i++)
            {
                left.Add(numbers[i]);
            }

            return left.ToArray();
        }
    }
}
