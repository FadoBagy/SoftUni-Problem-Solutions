using System;
using System.Linq;
using System.Collections.Generic;

public static void Main()
{
    var range = int.Parse(Console.ReadLine());
    var divisors = Console.ReadLine()
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .Distinct()
        .ToList();
    var divisibleNumbers = GetDivisibleNumbers(range, divisors);

    Console.WriteLine(string.Join(" ", divisibleNumbers));
}

private static List<int> GetDivisibleNumbers(int range, List<int> divisors)
{
    var divisibleNumbers = new List<int>();

    for (int num = 1; num <= range; num++)
    {
        var isDivisible = true;

        foreach (var divisor in divisors)
        {
            Predicate<int> isNotDivisor = x => num % x != 0;

            if (isNotDivisor(divisor))
            {
                isDivisible = false;
                break;
            }
        }

        if (isDivisible)
        {
            divisibleNumbers.Add(num);
        }
    }

    return divisibleNumbers;
}