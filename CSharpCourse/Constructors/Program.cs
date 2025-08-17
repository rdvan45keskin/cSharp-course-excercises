using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(123);
            customerManager.Add();
            customerManager.List();
            Product product2 = new Product();
            Product product3 = new Product(2, "Laptop");

            EmployeeManager employee = new EmployeeManager(new DatabaseLogger());

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 10;
            Console.WriteLine(Teacher.Number);

            Utilities.Validate();

            Manager.DoSomething();

            Manager manager = new Manager();
            manager.DoSomething2();



        }

        class CustomerManager
        {
            int _count = 0;
            public CustomerManager(int count)
            {
                _count = count;
            }

            public CustomerManager()
            {

            }
            public void List()
            {
                Console.WriteLine("Listed {0}", _count);
            }

            public void Add()
            {
                Console.WriteLine("Added");
            }
        }

        class Product
        {
            public Product()
            {

            }
            int _id;
            string _name;

            public Product(int id, string name)
            {
                _id = id;
                _name = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }

        }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged To Database");
        }
    }

    class FileLogger : ILogger 
    {
        public void Log() 
        {
            Console.WriteLine("Logged to Database");
        }
    }

    class EmployeeManager
    {
        ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add() 
        {
            _logger.Log();
            Console.WriteLine("Added");
        }
    }

    class BaseClass 
    {
        string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
        }

        public void Message() 
        {
            Console.WriteLine("{0} message",_entity);
        }    
    }

    class PersonManager : BaseClass 
    {
        public PersonManager(string entity):base(entity)    //base sınıfına entity yolluoz
        {
            
        }
        public void Add() 
        {
            Console.WriteLine("Added!");
            Message();
        }
    }

    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utilities
    {
        static Utilities() 
        {
            
        }
        public static void Validate() 
        {
            Console.WriteLine("Validation is done");
        }
    }

    class Manager 
    {
        public static void DoSomething() 
        {
            Console.WriteLine("Done");
        }

        public void DoSomething2() 
        {
            Console.WriteLine("Done 2");
        }
    }
}
