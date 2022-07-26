using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] steel = Console.ReadLine().Split(" ");
            string[] carbon = Console.ReadLine().Split(" ");
            var steelQueue = new Queue<int>();
            var carbonStack = new Stack<int>();
            for (int i = 0; i < steel.Length; i++)
            {
                steelQueue.Enqueue(int.Parse(steel[i]));
            }
            for (int i = 0; i < carbon.Length; i++)
            {
                carbonStack.Push(int.Parse(carbon[i]));
            }
            var weapons = new SortedDictionary<string, int>();
            while (steelQueue.Count > 0 && carbonStack.Count > 0)
            {
                int currentSteel = steelQueue.Dequeue();
                int currentCarbon = carbonStack.Pop();
                if (currentSteel + currentCarbon == 70)
                {
                    if (!weapons.ContainsKey("Gladius"))
                    {
                        weapons.Add("Gladius", 0);
                    }
                    weapons["Gladius"]++;
                }
                else if (currentSteel + currentCarbon == 80)
                {
                    if (!weapons.ContainsKey("Shamshir"))
                    {
                        weapons.Add("Shamshir", 0);
                    }
                    weapons["Shamshir"]++;
                }
                else if (currentSteel + currentCarbon == 90)
                {
                    if (!weapons.ContainsKey("Katana"))
                    {
                        weapons.Add("Katana", 0);
                    }
                    weapons["Katana"]++;
                }
                else if (currentSteel + currentCarbon == 110)
                {
                    if (!weapons.ContainsKey("Sabre"))
                    {
                        weapons.Add("Sabre", 0);
                    }
                    weapons["Sabre"]++;
                }
                else if (currentSteel + currentCarbon == 150)
                {
                    if (!weapons.ContainsKey("Broadsword"))
                    {
                        weapons.Add("Broadsword", 0);
                    }
                    weapons["Broadsword"]++;
                }
                else
                {
                    currentCarbon += 5;
                    carbonStack.Push(currentCarbon);
                }
            }
            int allWeapons = 0;
            foreach (var item in weapons)
            {
                allWeapons += item.Value;
            }
            if (weapons.Count > 0)
            {
                Console.WriteLine($"You have forged {allWeapons} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steelQueue.Count > 0)
            {
                Console.Write("Steel left: ");
                int index = 0;
                foreach (var item in steelQueue)
                {
                    if (index == steelQueue.Count - 1)
                    {
                        Console.Write($"{item}");
                    }
                    else
                    {
                        Console.Write($"{item}, ");
                    }
                    index++;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbonStack.Count > 0)
            {
                Console.Write("Carbon left: ");
                int index = 0;
                foreach (var item in carbonStack)
                {
                    if (index == carbonStack.Count - 1)
                    {
                        Console.Write($"{item}");
                    }
                    else
                    {
                        Console.Write($"{item}, ");
                    }
                    index++;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            foreach (var item in weapons)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
