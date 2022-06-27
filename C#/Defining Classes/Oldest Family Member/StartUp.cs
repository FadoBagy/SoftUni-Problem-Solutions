using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                var person = new Person(input[0], int.Parse(input[1]));
                family.AddMember(person);
            }
            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
