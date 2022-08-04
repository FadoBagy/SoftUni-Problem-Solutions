using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guestsCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] preapredFoods = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var guestQueue = new Queue<int>();
            var plateStack = new Stack<int>();
            for (int i = 0; i < guestsCapacity.Length; i++)
            {
                guestQueue.Enqueue(guestsCapacity[i]);
            }
            for (int i = 0; i < preapredFoods.Length; i++)
            {
                plateStack.Push(preapredFoods[i]);
            }
            int wastedFood = 0;
            for (int i = 0; i < guestsCapacity.Length; i++)
            {
                if (plateStack.Count > 0)
                {
                    var currentGuest = guestQueue.Dequeue();
                    for (int j = 0; j < preapredFoods.Length; j++)
                    {

                        var currentGramsOffood = plateStack.Pop();
                        if (currentGuest > currentGramsOffood)
                        {
                            currentGuest -= currentGramsOffood;
                        }
                        else
                        {
                            wastedFood += currentGramsOffood - currentGuest;
                            break;
                        }
                        if (currentGuest <= 0)
                        {
                            break;
                        }

                    }
                }
            }

            if (guestQueue.Count == 0)
            {
                Console.Write("Plates: ");
                int index = 0;
                foreach (var item in plateStack)
                {
                    if (index == plateStack.Count - 1)
                    {
                        Console.Write($"{item}");
                    }
                    else
                    {
                        Console.Write($"{item} ");
                    }
                    index++;
                }
            }
            else if (plateStack.Count == 0)
            {
                Console.Write("Guests: ");
                int index = 0;
                foreach (var item in guestQueue)
                {
                    if (index == guestQueue.Count - 1)
                    {
                        Console.Write($"{item}");
                    }
                    else
                    {
                        Console.Write($"{item} ");
                    }
                    index++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
