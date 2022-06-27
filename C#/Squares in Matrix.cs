using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SULectureCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                string[] chars = Console.ReadLine().Split(" ").ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            int index = 0;
            for (int row = 0; row < input[0]; row++)
            {
                for (int col = 0; col < input[1]; col++)
                {
                    if (row < input[0]-1 && col < input[1]-1)
                    {
                        if (matrix[row, col] == matrix[row, col + 1] && matrix[row + 1, col] == matrix[row + 1, col + 1] && matrix[row, col] == matrix[row + 1, col])
                        {
                            index++;
                        }
                    }
                }
            }
            Console.WriteLine(index);
        }
    }
}