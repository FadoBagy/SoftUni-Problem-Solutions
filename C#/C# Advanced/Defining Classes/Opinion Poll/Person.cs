using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
            name = "No name";
            age = 1;
        }
        public Person(int ageValue)
            : this()
        {
            age = ageValue;
        }
        public Person(string nameValue, int ageValue)
        {
            name = nameValue;
            age = ageValue;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string name;
        private int age;
    }
}
