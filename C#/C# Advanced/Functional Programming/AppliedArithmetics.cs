using System;
using System.Linq;
using System.Collections.Generic;

Func<List<int>, List<int>> addOne =
    x => x.Select(number => number + 1).ToList();

Func<List<int>, List<int>> multiplyByTwo =
    x => x.Select(number => number * 2).ToList();

Func<List<int>, List<int>> subtractOne =
    x => x.Select(number => number - 1).ToList();

Action<List<int>> print =
    x => Console.WriteLine(String.Join(" ", x));

List<int> numbers = Console.ReadLine()
    .Split()
    .Select(x => int.Parse(x))
    .ToList();

string command = Console.ReadLine();
while (command != "end")
{
    switch (command)
    {
        case "add":
            numbers = addOne(numbers);
            break;
        case "multiply":
            numbers = multiplyByTwo(numbers);
            break;
        case "subtract":
            numbers = subtractOne(numbers);
            break;
        case "print":
            print(numbers);
            break;
        default:
            break;
    }
    command = Console.ReadLine();
}