using System;

namespace DefiningClasses
{
    public class StartUp
    {
        class Person 
        {
            public string Name   
            {
                get { return name; }   
                set { name = value; } 
            }
            public int Age {
                get { return age; }
                set { age = value; }
            }
            private string name;
            private int age;
        }
        static void Main(string[] args)
        {
            var person1 = new Person();
            var person2 = new Person();
            var person3 = new Person();

            person1.Name = "Peter";
            person2.Name = "George";
            person3.Name = "Jose";
            person1.Age = 20;
            person2.Age = 18;
            person3.Age = 43;
        }
    }
}
