using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    class Program
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string word = Console.ReadLine();
            int[] shotpatameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] matrix = new char[size[0], size[1]];
            GetValue(size, matrix, word);


            int shotRow = shotpatameters[0];
            int shotCol = shotpatameters[1];
            int shotRadius = shotpatameters[2];


            makeShot(shotRadius, matrix, shotRow, shotCol);

            for (int col = 0; col < size[1]; col++)
            {
                runGravity(matrix, col);
            }


            Print(matrix);
        }

        private static void runGravity(char[,] matrix, int col)
        {

            while (true)
            {
                bool hahFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {

                    char curent = matrix[row, col];
                    char top = matrix[row - 1, col];
                    if (curent == ' ' && top != ' ')
                    {
                        matrix[row, col] = top;
                        matrix[row - 1, col] = ' ';
                        hahFallen = true;
                    }

                }
                if (!hahFallen)
                {
                    break;
                }
            }
        }

        private static void makeShot(int shotRadius, char[,] matrix, int shotRow, int shotCol)
        {
            
            matrix[shotRow, shotCol] = ' ';
            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsInsideRadius(row, col, shotRow, shotCol, shotRadius))
                    {
                        matrix[row,col] = ' ';
                    }
                }
            }

        }
        private static bool IsInsideRadius(int checkRow, int checkCol, int impactRow, int impactCol, int shotRadius)
        {
            int deltaRow = checkRow - impactRow;
            int deltaCol = checkCol - impactCol;

            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

            return isInRadius;
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void GetValue(int[] size, char[,] matrix, string word)
        {
            int i = 0;
            bool sw = true;
            for (int row = size[0] - 1; row >= 0; row--)
            {
                if (sw)
                {
                    for (int col = size[1] - 1; col >= 0; col--)
                    {
                        matrix[row, col] = word[i];
                        i++;
                        if (i > word.Length - 1)
                        {
                            i = 0;
                        }
                    }
                    sw = !sw;
                }
                else
                {
                    for (int col = 0; col < size[1]; col++)
                    {
                        matrix[row, col] = word[i];
                        i++;
                        if (i > word.Length - 1)
                        {
                            i = 0;
                        }
                    }
                    sw = !sw;
                }
            }
        }
    }
}
