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
                var numbers = Console.ReadLine().Split(new[] { ' ' } , StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "END")
                {
                    break;
                }
                else if (command[0] == "swap")
                {
                    if (command.Length <= 5 && 
                        int.Parse(command[1]) < matrix.GetLength(0) && int.Parse(command[2]) < matrix.GetLength(1) &&
                        int.Parse(command[3]) < matrix.GetLength(0) && int.Parse(command[4]) < matrix.GetLength(1))
                    {
                        string firstElementToSwap = matrix[int.Parse(command[1]), int.Parse(command[2])];
                        string secoundElementToSwap = matrix[int.Parse(command[3]), int.Parse(command[4])];
                        matrix[int.Parse(command[1]), int.Parse(command[2])] = secoundElementToSwap;
                        matrix[int.Parse(command[3]), int.Parse(command[4])] = firstElementToSwap;
                        for (int row = 0; row < input[0]; row++)
                        {
                            for (int col = 0; col < input[1]; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

        }
    }
}