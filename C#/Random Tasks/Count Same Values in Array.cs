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
            double[] numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            var numDictionary = new Dictionary<double, int>();
            foreach (var item in numbers)
            {
                if (!numDictionary.ContainsKey(item))
                {
                    numDictionary.Add(item, 1);
                }
                else
                {
                    numDictionary[item]++;
                }
            }

            foreach (var item in numDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}