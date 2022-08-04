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
            int[,] matrix = new int[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                int[] numbers = Console.ReadLine().Split(new[] { ' ' } , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            int maxSum = int.MinValue;
            int[,] maxMatrix = new int[3, 3];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row < matrix.GetLength(0)-2 && col < matrix.GetLength(1)-2)
                    {
                        if (
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2] > maxSum)
                        {
                            maxSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                            matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                            matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                            maxMatrix[0, 0] = matrix[row, col];
                            maxMatrix[0, 1] = matrix[row, col+1];
                            maxMatrix[0, 2] = matrix[row, col+2];
                            maxMatrix[1, 1] = matrix[row+1, col + 1];
                            maxMatrix[1, 0] = matrix[row+1, col];
                            maxMatrix[1, 2] = matrix[row+1, col + 2];
                            maxMatrix[2, 0] = matrix[row+2, col];
                            maxMatrix[2, 1] = matrix[row+2, col + 1];
                            maxMatrix[2, 2] = matrix[row+2, col + 2];
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < maxMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < maxMatrix.GetLength(1); col++)
                {
                    Console.Write($"{maxMatrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}