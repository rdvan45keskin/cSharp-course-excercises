using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[]
            {
                new Customer{FirstName = "Engin" },
                new Student{FirstName = "Nicat"},
                new Person{FirstName = "Selo" }
            };

            foreach (Person person in persons) 
            {
                Console.WriteLine(person.FirstName);
            }
        }

        class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Customer : Person
        {
            public string City { get; set; }
        }

        class Student : Person 
        {
            public int Number { get; set; }
        }

        
    }
}
