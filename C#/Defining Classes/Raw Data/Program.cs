using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            List<Cargo> cargos = new List<Cargo>();
            List<List<Tire>> tires = new List<List<Tire>>();
            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                var cargo = new Cargo(int.Parse(input[3]), input[4]);
                var tire1 = new Tire(double.Parse(input[5]), int.Parse(input[6]));
                var tire2 = new Tire(double.Parse(input[7]), int.Parse(input[8]));
                var tire3 = new Tire(double.Parse(input[9]), int.Parse(input[10]));
                var tire4 = new Tire(double.Parse(input[11]), int.Parse(input[12]));
                var car = new Car(input[0], engine, cargo, tire1, tire2, tire3, tire4);
                cars.Add(car);
                engines.Add(engine);
                cargos.Add(cargo);
                List<Tire> currentTires = new List<Tire>();
                currentTires.Add(tire1);
                currentTires.Add(tire2);
                currentTires.Add(tire3);
                currentTires.Add(tire4);
                tires.Add(currentTires);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cargos[i].Type == "fragile")
                    {
                        for (int j = 0; j < tires[i].Count; j++)
                        {
                            if (tires[i][j].Pressure < 1)
                            {
                                Console.WriteLine(cars[i].Model);
                                break;
                            }
                        }
                    }
                }
            }
            if (command == "flammable")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cargos[i].Type == "flammable" && engines[i].Power > 250)
                    {
                        Console.WriteLine(cars[i].Model);
                    }
                }
            }
        }
    }
}
