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
            int input = int.Parse(Console.ReadLine());
            int[,] matrix = new int[input, input];

            for (int row = 0; row < input; row++)
            {
                int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < input; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum1 = 0;
            int sum2 = 0;
            int index1 = 0;
            int index2 = matrix.GetLength(0)-1;

            for (int row = 0; row < input; row++)
            {
                for (int col = 0; col < input; col++)
                {
                    if (index1 == col)
                    {
                        sum1 += matrix[row, col];
                        index1++;
                        break;
                    }
                }
            }
            for (int row = 0; row < input; row++)
            {
                for (int col = matrix.GetLength(0)-1; col >= 0; col--)
                {
                    if (index2 == col)
                    {
                        sum2 += matrix[row, col];
                        index2--;
                        break;
                    }
                }
            }
            Console.WriteLine(Math.Abs(sum1-sum2));
        }
    }
    /*  
3
11 2 4
4 5 6
10 8 -12
    */
}