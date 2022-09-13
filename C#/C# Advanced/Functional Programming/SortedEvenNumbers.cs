using System;
using System.Linq;

Func<string, int> parseStringToInt =
    x => int.Parse(x);

Func<int, bool> isEven =
    x => x % 2 == 0;

Func<int, int> identity =
    x => x;

int[] numbers = Console.ReadLine()
        .Split(new String[] { ", " },
        StringSplitOptions.RemoveEmptyEntries)
        .Select(parseStringToInt)
        .Where(isEven)
        .OrderBy(identity)
        .ToArray();

Console.WriteLine(String.Join(", ", numbers));