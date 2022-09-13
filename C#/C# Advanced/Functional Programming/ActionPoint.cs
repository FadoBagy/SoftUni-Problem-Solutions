using System;
using System.Collections.Generic;
using System.Linq;

List<string> names = Console.ReadLine().Split().ToList();

Action<string> print = x => Console.WriteLine(x);

names.ForEach(print);