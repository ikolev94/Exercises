using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parachute
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            List<string> matrix = new List<string>();
            bool isItEnd = true;
            int row = 0;
            int tempRow = 0;
            while (line != "END")
            {
                matrix.Add(line);
                if (line.Contains('o'))
                {
                    row = tempRow;
                }
                line = Console.ReadLine();
                isItEnd = false;
                tempRow++;
            }
            if (isItEnd)
            {
                return;
            }

            int startCol = matrix[row].IndexOf('o');
            row++;
            int previusCol = startCol;
            while (true)
            {
                int windPower = FindWindPower(matrix, row);
                previusCol += windPower;
                switch (matrix[row][previusCol])
                {
                    case '~':
                        Console.WriteLine("Drowned in the water like a cat!");
                        Console.WriteLine(String.Format("{0} {1}", row, previusCol));
                        return;
                    case '_':
                        Console.WriteLine("Landed on the ground like a boss!");
                        Console.WriteLine(String.Format("{0} {1}", row, previusCol));
                        return;
                    case '/':
                        Console.WriteLine("Got smacked on the rock like a dog!");
                        Console.WriteLine(String.Format("{0} {1}", row, previusCol));
                        return;
                    case '|':
                        Console.WriteLine("Got smacked on the rock like a dog!");
                        Console.WriteLine(String.Format("{0} {1}", row, previusCol));
                        return;
                    case '\\':
                        Console.WriteLine("Got smacked on the rock like a dog!");
                        Console.WriteLine(String.Format("{0} {1}", row, previusCol));
                        return;
                }
                row++;
                if (row >= matrix.Count)
                {
                    break;
                }

            }
        }

        private static int FindWindPower(List<string> matrix, int row)
        {
            int windPower = 0;
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == '>')
                {
                    windPower++;
                }
                if (matrix[row][col] == '<')
                {
                    windPower--;
                }
            }
            return windPower;
        }
    }
}
