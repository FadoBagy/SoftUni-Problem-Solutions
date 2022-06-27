using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            var dir = new SortedDictionary<string, int>();
            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (int.Parse(input[1]) > 30)
                {
                    dir.Add(input[0], int.Parse(input[1]));
                }
            }
            foreach (var item in dir)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
