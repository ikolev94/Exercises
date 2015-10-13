namespace RadioactiveMutantVampireBunnies
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] matrix = new char[size[0]][];
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('P'))
                {
                    playerRow = i;
                    playerCol = Array.IndexOf(matrix[i], 'P');
                    matrix[playerRow][playerCol] = '.';
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            foreach (var command in commands)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;
                switch (command)
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                }

                matrix = SpreadBunnies(matrix);

                if (playerRow < 0 || playerRow >= matrix.Length || playerCol < 0
                    || playerCol >= matrix[playerRow].Length)
                {
                    PrintMatrix(matrix, oldPlayerRow, oldPlayerCol, "won");
                    return;
                }

                if (matrix[playerRow][playerCol] == 'B')
                {
                    PrintMatrix(matrix, playerRow, playerCol, "dead");
                    return;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix, int row, int col, string result)
        {
            foreach (char[] line in matrix)
            {
                foreach (var ch in line)
                {
                    Console.Write(ch);
                }

                Console.WriteLine();
            }

            Console.WriteLine("{0}: {1} {2}", result, row, col);
        }

        private static char[][] SpreadBunnies(char[][] matrix)
        {
            char[][] newMatrix = new char[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                newMatrix[i] = (char[])matrix[i].Clone();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'B')
                    {
                        if (i - 1 >= 0)
                        {
                            newMatrix[i - 1][j] = 'B';
                        }

                        if (i + 1 < matrix.Length)
                        {
                            newMatrix[i + 1][j] = 'B';
                        }

                        if (j - 1 >= 0)
                        {
                            newMatrix[i][j - 1] = 'B';
                        }

                        if (j + 1 < matrix[i].Length)
                        {
                            newMatrix[i][j + 1] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }
    }
}