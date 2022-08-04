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
            int times = int.Parse(Console.ReadLine());
            var elements = new SortedDictionary<string, int>();
            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    if (!elements.ContainsKey(input[j]))
                    {
                        elements.Add(input[j], 0);
                    }
                }
            }
            foreach (var item in elements)
            {
                Console.Write(item.Key + " ");
            }
        }
    }
}