using System;
using System.Linq;

Func<string, int> parseStringToInt =
    x => int.Parse(x);

Func<int[], int> arrayCount =
    x => x.Count();

Func<int[], int> arraySum =
    x => x.Sum();

int[] numbers = Console.ReadLine()
    .Split(new String[] { ", " },
    StringSplitOptions.RemoveEmptyEntries)
    .Select(parseStringToInt)
    .ToArray();

Console.WriteLine("Length: " + arrayCount(numbers));
Console.WriteLine("Sum: " + arraySum(numbers));