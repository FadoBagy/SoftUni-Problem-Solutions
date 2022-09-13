using System;
using System.Linq;

Predicate<string> isOdd =
    x => x == "odd";
Predicate<string> isEven =
    x => x == "even";

int[] range = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
string type = Console.ReadLine();

for (int i = range[0]; i <= range[1]; i++)
{
    if (isOdd(type))
    {
        if (i % 2 != 0)
        {
            Console.Write(i + " ");
        }
    }
    else if (isEven(type))
    {
        if (i % 2 == 0)
        {
            Console.Write(i + " ");
        }
    }
}