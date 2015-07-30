using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Shuffle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            input = input.PadRight(n * n, ' ');
            char[,] matrix = new char[n, n];
            string blackLetters = string.Empty;
            string whiteLetters = string.Empty;


            int row = 0;
            int col = 0;
            string direction = "right";
            int maxRotations = n * n;
            GetValue(maxRotations, direction, col, n, matrix, row, input);
            //print(n, matrix);

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {

                    if (r % 2 == 0)
                    {
                        if (c % 2 == 0)
                        {
                            whiteLetters += matrix[r, c];
                        }
                        else
                        {
                            blackLetters += matrix[r, c];
                        }

                    }
                    else
                    {
                        if (c % 2 == 0)
                        {
                            blackLetters += matrix[r, c];
                        }
                        else
                        {
                            whiteLetters += matrix[r, c];
                        }

                    }

                }
            }
            string noSpases = RemoveWhiteSpaces(blackLetters, whiteLetters);
            string recerceNoSpace = Reverce(noSpases);
            if (noSpases == recerceNoSpace)
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", whiteLetters + blackLetters);
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", whiteLetters + blackLetters);
            }




        }

        private static string Reverce(string noSpases)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = noSpases.Length - 1; i >= 0; i--)
            {
                sb.Append(noSpases[i]);
            }
            return sb.ToString();
        }



        private static string RemoveWhiteSpaces(string blackLetters, string whiteLetters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(whiteLetters.ToLower());
            sb.Append(blackLetters.ToLower());
            sb.Replace(" ", string.Empty);
            return sb.ToString();
        }

        private static void print(int n, char[,] matrix)
        {
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write("{0,4}", matrix[r, c]);
                }
                Console.WriteLine();
            }
        }

        private static void GetValue(int maxRotations, string direction, int col, int n, char[,] matrix, int row, string input)
        {
            int count = 0;
            for (int i = 1; i <= maxRotations; i++)
            {
                if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = "left";
                    row--;
                    col--;
                }
                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col++;
                    row--;
                }

                if (direction == "up" && row < 0 || matrix[row, col] != 0)
                {
                    direction = "right";
                    row++;
                    col++;
                }
                matrix[row, col] = input[count];
                count++;

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }
        }


    }
}



