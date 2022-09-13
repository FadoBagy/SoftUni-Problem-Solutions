using System;
using System.Linq;

int length = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine()
    .Split()
    .ToArray();

Predicate<string> asd =
    x => x.Length <= length;

foreach (var name in names)
{
    if (asd(name))
    {
        Console.WriteLine(name);
    }
}