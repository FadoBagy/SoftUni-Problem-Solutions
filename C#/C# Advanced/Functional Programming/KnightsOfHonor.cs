using System;
using System.Collections.Generic;
using System.Linq;

List<string> names = Console.ReadLine().Split().ToList();

Action<string> appedSir = x => Console.WriteLine("Sir " + x);

names.ForEach(appedSir);