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
            string input = Console.ReadLine();
            var dir = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dir.ContainsKey(input[i]))
                {
                    dir.Add(input[i], 1);
                }
                else
                {
                    dir[input[i]]++;
                }
            }
            foreach (var item in dir)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}