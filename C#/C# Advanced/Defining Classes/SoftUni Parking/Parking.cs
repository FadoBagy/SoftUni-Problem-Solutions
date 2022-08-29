using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacityValue)
        {
            capacity = capacityValue;
        }
        public List<Car> Cars = new List<Car>();
        public int Count  
        {
            get { return currentCapacity; }   
            set { currentCapacity = value; }  
        }
        private int capacity;
        private int currentCapacity;
        public string AddCar(Car car)
        {
            bool isPresent = false;
            for (int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].RegistrationNumber == car.RegistrationNumber)
                {
                    isPresent = true;
                }
            }
            if (isPresent == true)
            {
                return "Car with that registration number, already exists!";
            }
            else
            {
                if (currentCapacity < capacity)
                {
                    Cars.Add(car);
                    currentCapacity++;
                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
                else
                {
                    return "Parking is full!";
                }
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            bool isPresent = false;
            for (int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].RegistrationNumber == registrationNumber)
                {
                    Cars.Remove(Cars[i]);
                    currentCapacity--;
                    isPresent = true;
                    return $"Successfully removed {registrationNumber}";
                }
            }
            if (isPresent == false)
            {
                return "Car with that registration number, doesn't exist!";
            }
            return null;
        }
        public Car GetCar(string registrationNumber)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].RegistrationNumber == registrationNumber)
                {
                    return Cars[i];
                }
            }
            return null;
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                for (int j = 0; j < Cars.Count; j++)
                {
                    if (registrationNumbers[i] == Cars[j].RegistrationNumber)
                    {
                        Cars.Remove(Cars[j]);
                        currentCapacity--;
                    }
                }
            }
        }
    }
}
