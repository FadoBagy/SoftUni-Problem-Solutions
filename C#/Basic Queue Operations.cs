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
            int[] number = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> numbersQueue = new Queue<int>();
            for (int i = 0; i < number.Length; i++)
            {
                numbersQueue.Enqueue(number[i]);
            }
            if (numbersQueue.Count > 0)
            {
                for (int i = 0; i < input[1]; i++)
                {
                    numbersQueue.Dequeue();
                }
                if (numbersQueue.Count > 0)
                {
                    int smallestNumber = numbersQueue.Peek();
                    bool isPresent = false;
                    for (int i = numbersQueue.Count; i > 0; i--)
                    {
                        int currentNumber = numbersQueue.Dequeue();
                        if (currentNumber == input[2])
                        {
                            isPresent = true;
                        }
                        if (currentNumber < smallestNumber)
                        {
                            smallestNumber = currentNumber;
                        }
                    }
                    if (isPresent == true)
                    {
                        Console.WriteLine("true");
                    }
                    else
                    {
                        Console.WriteLine(smallestNumber);
                    }
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
                
        }
    }
}