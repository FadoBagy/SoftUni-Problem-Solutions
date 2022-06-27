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
            int[] numberToCheck = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> numbersStack = new Stack<int>();

            for (int i = 0; i < numberToCheck.Length; i++)
            {
                numbersStack.Push(numberToCheck[i]);
            }


            for (int i = 0; i < input[1]; i++)
            {
                if (numbersStack.Count > 0)
                {
                    numbersStack.Pop();
                }
            }

            
            if (numbersStack.Count > 0)
            {
                int smallestNum = numbersStack.Peek();
                bool isPresent = false;
                for (int i = numbersStack.Count; i > 0; i--)
                {
                    int currentNum = numbersStack.Pop();
                    if (currentNum < smallestNum)
                    {
                        smallestNum = currentNum;
                    }
                    if (currentNum == input[2])
                    {
                        isPresent = true;
                    }
                }

                if (isPresent == true)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(smallestNum);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}