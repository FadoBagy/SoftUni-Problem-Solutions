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
            var dir = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (!dir.ContainsKey(input[0]))
                {
                    dir[input[0]] = new List<decimal>();
                    dir[input[0]].Add(decimal.Parse(input[1]));
                }
                else
                {
                    dir[input[0]].Add(decimal.Parse(input[1]));
                }
            }
            foreach (var item in dir)
            {
                decimal avg = Queryable.Average(item.Value.AsQueryable());
                List<decimal> grades = item.Value;
                Console.Write($"{item.Key} -> ");
                foreach (var grade in grades)
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.Write($"(avg: {avg:F2})");
                Console.WriteLine();
            }
        }
    }
}