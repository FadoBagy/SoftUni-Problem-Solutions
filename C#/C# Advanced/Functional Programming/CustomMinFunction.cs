using System;
using System.Linq;

Func<int[], int> smallestNumber = x => x.Min();

int[] numbers = Console.ReadLine()
    .Split()
    .Select(x => int.Parse(x))
    .ToArray();

Console.WriteLine(smallestNumber(numbers));