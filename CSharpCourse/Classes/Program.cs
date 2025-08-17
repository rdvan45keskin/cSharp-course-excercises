using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();

            //constuctora bişeyler verme
            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "Test";
            customer.LastName = "Test";
            customer.Address = "Test";

            //farklı bir yöntem
            Customer customer1 = new Customer 
            {
                Id = 1,FirstName = "Test",LastName = "Test",Address = "Test"    
            };

            Console.WriteLine(customer1.FirstName);
        }

        


    }
}
