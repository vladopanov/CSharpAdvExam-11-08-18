using System;

namespace _2.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (byte i = 0; i < n; i++) {
                char[] line = Console.ReadLine().ToCharArray();
                matrix[i] = line;
            }
            char[] directions = Console.ReadLine().ToCharArray();

            Run(matrix, directions);           

            PrintMatrix(matrix);
        }

        private static void Run(char[][] matrix, char[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                // Move patrols
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'b')
                        {
                            if (col == matrix[row].Length - 1)
                            {
                                matrix[row][col] = 'd';
                                break;
                            }
                            else
                            {
                                matrix[row][col] = '.';
                                matrix[row][col + 1] = 'b';
                                break;
                            }
                        }

                        if (matrix[row][col] == 'd')
                        {
                            if (col == 0)
                            {
                                matrix[row][col] = 'b';
                                break;
                            }
                            else
                            {
                                matrix[row][col] = '.';
                                matrix[row][col - 1] = 'd';
                                break;
                            }
                        }
                    }
                }
                // End moving patrols

                // Check if Sam dies
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (Array.IndexOf(matrix[row], 'S') > -1)
                        {
                            int index = Array.IndexOf(matrix[row], 'S');
                            for (int z = 0; z < index; z++)
                            {
                                if (matrix[row][z] == 'b')
                                {
                                    matrix[row][index] = 'X';
                                    Console.WriteLine($"Sam died at {row}, {index}");
                                    return;
                                }
                            }
                            for (int z = matrix[row].Length - 1; z > index; z--)
                            {
                                if (matrix[row][z] == 'd')
                                {
                                    matrix[row][index] = 'X';
                                    Console.WriteLine($"Sam died at {row}, {index}");
                                    return;
                                }
                            }
                        }
                    }
                }

                char direction = directions[i];
                bool isBreak = false;
                switch (direction)
                {
                    case 'U':
                        for (int row = 0; row < matrix.Length; row++)
                        {
                            if (isBreak) { break; }
                            for (int col = 0; col < matrix[row].Length; col++)
                            {
                                if (matrix[row][col] == 'S')
                                {
                                    matrix[row][col] = '.';
                                    if (Array.IndexOf(matrix[row - 1], 'N') > -1)
                                    {
                                        Console.WriteLine("Nikoladze killed!");
                                        matrix[row - 1][Array.IndexOf(matrix[row - 1], 'N')] = 'X';
                                        matrix[row - 1][col] = 'S';
                                        return;
                                    }
                                    matrix[row - 1][col] = 'S';
                                    isBreak = true;
                                    break;
                                }
                            }
                        }
                        break;

                    case 'D':
                        for (int row = 0; row < matrix.Length; row++)
                        {
                            if (isBreak) { break; }
                            for (int col = 0; col < matrix[row].Length; col++)
                            {
                                if (matrix[row][col] == 'S')
                                {
                                    matrix[row][col] = '.';
                                    if (Array.IndexOf(matrix[row + 1], 'N') > -1)
                                    {
                                        Console.WriteLine("Nikoladze killed!");
                                        matrix[row + 1][Array.IndexOf(matrix[row + 1], 'N')] = 'X';
                                        matrix[row + 1][col] = 'S';
                                        return;
                                    }
                                    matrix[row + 1][col] = 'S';
                                    isBreak = true;
                                    break;
                                }
                            }
                        }
                        break;

                    case 'L':
                        for (int row = 0; row < matrix.Length; row++)
                        {
                            for (int col = 0; col < matrix[row].Length; col++)
                            {
                                char currentCell = matrix[row][col];
                                if (currentCell == 'S')
                                {
                                    matrix[row][col] = '.';
                                    matrix[row][col - 1] = 'S';
                                    break;
                                }
                            }
                        }
                        break;

                    case 'R':
                        for (int row = 0; row < matrix.Length; row++)
                        {
                            for (int col = 0; col < matrix[row].Length; col++)
                            {
                                char currentCell = matrix[row][col];
                                if (currentCell == 'S')
                                {
                                    matrix[row][col] = '.';
                                    matrix[row][col + 1] = 'S';
                                    break;
                                }
                            }
                        }
                        break;
                    case 'W': break;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
