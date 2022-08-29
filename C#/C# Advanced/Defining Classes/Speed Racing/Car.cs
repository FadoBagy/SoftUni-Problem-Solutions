using System;
using System.Collections.Generic;
using System.Text;

namespace CarProblem
{
    public class Car
    {
        public Car(string model, int fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0.0;

        public void DistanceCalculate(int amountOfKm) 
        {
            if (amountOfKm * FuelConsumptionPerKilometer > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                TravelledDistance += amountOfKm;
                FuelAmount -= amountOfKm * FuelConsumptionPerKilometer;
            }
        }
    }
}
