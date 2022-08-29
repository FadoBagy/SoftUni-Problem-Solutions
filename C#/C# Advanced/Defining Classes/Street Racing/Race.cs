using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> Participants = new List<Car>();
        private int currentCapacity = 0;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count
        {
            get
            {
                return this.Participants.Count;
            }
        }
        public void Add(Car car)
        {
            if (this.Capacity > currentCapacity)
            {
                if (car.HorsePower <= this.MaxHorsePower)
                {
                    bool isThere = false;
                    for (int i = 0; i < this.Participants.Count; i++)
                    {
                        if (Participants[i].LicensePlate == car.LicensePlate)
                        {
                            isThere = true;
                        }
                    }
                    if (isThere == false)
                    {
                        Participants.Add(car);
                        currentCapacity++;
                    }
                }
            }
        }
        public bool Remove(string licensePlate)
        {
            bool isThere = false;
            for (int i = 0; i < this.Participants.Count; i++)
            {
                if (Participants[i].LicensePlate == licensePlate)
                {
                    isThere = true;
                    Participants.Remove(Participants[i]);
                    currentCapacity--;
                }
            }
            return isThere;
        }
        public Car FindParticipant(string licensePlate)
        {
            for (int i = 0; i < this.Participants.Count; i++)
            {
                if (Participants[i].LicensePlate == licensePlate)
                {
                    return Participants[i];
                }
            }
            return null;
        }
        public Car GetMostPowerfulCar() 
        {
            int hightestHorsePower = int.MinValue;
            var theBestCar = new Car(null, null, null, 0, 0.0);
            for (int i = 0; i < this.Participants.Count; i++)
            {
                if (Participants[i].HorsePower > hightestHorsePower)
                {
                    hightestHorsePower = Participants[i].HorsePower;
                    theBestCar = Participants[i];
                }
            }
            if (hightestHorsePower == int.MinValue)
            {
                return null;
            }
            return theBestCar;
        }
        public string Report() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
