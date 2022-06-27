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
            List<int> input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int[,] numberArray2D = new int[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
                for (int col = 0; col < input[1]; col++)
                {
                    numberArray2D[row, col] = numbers[col];
                }
            }

            int theBiggestSum = 0;
            int theBiggest1 = 0;
            int theBiggest2 = 0;
            int theBiggest3 = 0;
            int theBiggest4 = 0;

            for (int row = 0; row < input[0]; row++)
            {
                for (int col = 0; col < input[1]; col++)
                {
                    if (col < input[1]-1 && row < input[0]-1)
                    {
                        int number1 = numberArray2D[row, col];
                        int number2 = numberArray2D[row, col + 1];
                        int number3 = numberArray2D[row + 1, col];
                        int number4 = numberArray2D[row + 1, col + 1];
                        int currentSum = number1 + number2 + number3 + number4;
                        if (currentSum > theBiggestSum)
                        {
                            theBiggestSum = currentSum;
                            theBiggest1 = number1;
                            theBiggest2 = number2;
                            theBiggest3 = number3;
                            theBiggest4 = number4;
                        }
                    }
                }
            }
            Console.WriteLine($"{theBiggest1} {theBiggest2} ");
            Console.WriteLine($"{theBiggest3} {theBiggest4} ");
            Console.WriteLine(theBiggestSum);

        }
    }
}