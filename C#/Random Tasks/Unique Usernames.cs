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
            var usernames = new Dictionary<string, int>();
            for (int i = 0; i < times; i++)
            {
                var input = Console.ReadLine();
                if (!usernames.ContainsKey(input))
                {
                    usernames.Add(input, 0);
                }
            }
            foreach (var item in usernames)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}