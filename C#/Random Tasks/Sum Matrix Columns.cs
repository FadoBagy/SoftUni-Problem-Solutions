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
            int[] matrixParameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixParameters[0], matrixParameters[1]];
            for (int i = 0; i < matrixParameters[0]; i++)
            {
                int[] line = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrixParameters[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                }
            }

            for (int i = 0; i < matrixParameters[1]; i++)
            {
                int sum = 0;

                for (int j = 0; j < matrixParameters[0]; j++)
                {
                    sum += matrix[j, i];

                }
                Console.WriteLine(sum);

            }
        }
    }
}