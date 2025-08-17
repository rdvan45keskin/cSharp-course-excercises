using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
//klonlama yapıyoz yeni referans oluşturmadan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer {FirstName = "Engin",LastName = "Demiroğ",City = "Ankara",Id = 1};
            Console.WriteLine(customer1.FirstName);

            Customer customer2 = (Customer)customer1.Clone();
            customer2.City = "Ankara";
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);


            
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
