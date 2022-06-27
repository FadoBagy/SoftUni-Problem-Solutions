using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(string model, Engine engin, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
        {
            Model = model;
        }
        public string Model { get; set; }

    }
}
