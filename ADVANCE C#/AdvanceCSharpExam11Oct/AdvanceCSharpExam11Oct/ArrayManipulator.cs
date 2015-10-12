namespace AdvanceCSharpExam11Oct
{
    using System;
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
                        if (int.Parse(commandArgs[1]) >= numbers.Length || int.Parse(commandArgs[1]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        numbers = Exchange(int.Parse(commandArgs[1]), numbers);
                        break;
                    case "min":
                        int indexOfMin = FindMin(commandArgs[1], numbers);
                        Console.WriteLine(indexOfMin >= 0 ? indexOfMin + string.Empty : "No matches");
                        break;
                    case "max":
                        int indexOfMax = FindMax(commandArgs[1], numbers);
                        Console.WriteLine(indexOfMax >= 0 ? indexOfMax + string.Empty : "No matches");
                        break;
                    case "first":
                        int[] resultFirst = First(int.Parse(commandArgs[1]), commandArgs[2], numbers);
                        if (resultFirst == null)
                        {
                            break;
                        }

                        Console.WriteLine("[" + string.Join(", ", resultFirst) + "]");
                        break;
                    case "last":
                        int[] resultLast = Last(int.Parse(commandArgs[1]), commandArgs[2], numbers);
                        if (resultLast == null)
                        {
                            break;
                        }

                        Console.WriteLine("[" + string.Join(", ", resultLast) + "]");
                        break;
                }
            }

            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }

        private static int[] Last(int count, string evenOrOdd, int[] numbers)
        {
            int numsLength = numbers.Length;
            if (count > numsLength)
            {
                Console.WriteLine("Invalid count");
                return null;
            }

            bool isOdd = evenOrOdd == "odd";
            if (isOdd)
            {
                return numbers.Where(n => n % 2 == 1).Reverse().Take(count).Reverse().ToArray();
            }

            return numbers.Where(n => n % 2 == 0).Reverse().Take(count).Reverse().ToArray();
        }

        private static int[] First(int count, string evenOrOdd, int[] numbers)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return null;
            }

            bool isOdd = evenOrOdd == "odd";
            if (isOdd)
            {
                return numbers.Where(n => n % 2 == 1).Take(count).ToArray();
            }

            return numbers.Where(n => n % 2 == 0).Take(count).ToArray();
        }

        private static int FindMax(string evenOrOdd, int[] numbers)
        {
            int div = evenOrOdd == "odd" ? 1 : 0;
            int max = int.MinValue;
            int index = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max <= numbers[i] && numbers[i] % 2 == div)
                {
                    max = numbers[i];
                    index = i;
                }
            }

            return index;
        }

        private static int FindMin(string evenOrOdd, int[] numbers)
        {
            int div = evenOrOdd == "odd" ? 1 : 0;
            int min = int.MaxValue;
            int index = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (min >= numbers[i] && numbers[i] % 2 == div)
                {
                    min = numbers[i];
                    index = i;
                }
            }

            return index;
        }

        private static int[] Exchange(int index, int[] numbers)
        {
            var result = numbers.Skip(index + 1).ToList();
            for (int i = 0; i < index + 1; i++)
            {
                result.Add(numbers[i]);
            }

            return result.ToArray();
        }
    }
}
