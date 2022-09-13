using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split()
    .Select(x => int.Parse(x))
    .ToArray();
int integerN = int.Parse(Console.ReadLine());

Action<int[]> reverseArray =
    x => Array.Reverse(x);
Func<int, bool> isDevided =
    x => x % integerN != 0;

reverseArray(numbers);
foreach (var number in numbers)
{
    if (isDevided(number))
    {
        Console.Write(number + " ");
    }
}