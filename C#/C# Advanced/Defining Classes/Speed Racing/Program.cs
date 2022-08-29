using System;
using System.Collections.Generic;
using System.IO;

namespace CarProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                var car = new Car(input[0], int.Parse(input[1]), double.Parse(input[2]));
                cars.Add(car);
            }
            while (true)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (input[0] == "End")
                {
                    break;
                }
                if (input[0] == "Drive")
                {
                    for (int i = 0; i < cars.Count; i++)
                    {
                        if (input[1] == cars[i].Model)
                        {
                            cars[i].DistanceCalculate(int.Parse(input[2]));
                        }
                    }
                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.TravelledDistance}");
            }
        }
    }
}
