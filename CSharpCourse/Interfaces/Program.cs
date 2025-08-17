using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        //Ipersondan miras vererek personu kullanarak diğer özelliklere erişebiliyoz
        static void Main(string[] args)
        {
            //InterfacesIntro();

            //Demo();
            
            ICustomerDal[] customerDals = new ICustomerDal[]
            {
                new SqlServerCustomerDal(),
                new OracleCustomerDal(),
                new MySqlCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                //1-) SqlServerCustomerDal().Add oldu
                //2-) new OracleCustomerDal().Add oldu
                customerDal.Add();
            }
        }

        private static void Demo() 
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Add(new OracleCustomerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager personManager = new PersonManager();
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Nicat",
                LastName = "Isler",
                Adress = "Deneme"
            };
            personManager.Add(customer);

            Student student = new Student
            {
                Id = 1,
                FirstName = "Velet",
                LastName = "Selo",
                Department = "C# dev."
            };
            personManager.Add(student);
        }
        interface IPerson
        {
            int Id { get; set; }
            string FirstName { get; set; }
            string LastName { get; set; }

        }

        class Customer : IPerson
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Adress { get; set; }
        }

        class Student : IPerson
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Department { get; set; }
        }

        class PersonManager
        {
            public void Add(IPerson person)
            {
                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);
            }
        }
    }
}