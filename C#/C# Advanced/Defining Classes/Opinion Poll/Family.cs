using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public List<Person> listOfPeople = new List<Person>();
        public void AddMember(Person member) 
        {
            listOfPeople.Add(member);
        }
        public Person GetOldestMember() 
        {
            var oldestMember = listOfPeople[0];
            var highestAge = int.MinValue;
            for (int i = 0; i < listOfPeople.Count; i++)
            {
                if (listOfPeople[i].Age > highestAge)
                {
                    highestAge = listOfPeople[i].Age;
                    oldestMember = listOfPeople[i];
                }
            }
            return oldestMember;
        }
    }
}
