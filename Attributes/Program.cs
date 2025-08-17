using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer {Id = 1, LastName = "Keskin", Age = 21 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);      //bu method eski demek

        }
    }
    [ToTable("Customers")]
    [ToTable("TblCustomers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        //bunu kullanma yenisini kullan demek için kullanılan attribute
        [Obsolete("Dont use Add, instead use AddNew method")]
        public void Add(Customer customer)
        {
            Console.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Age} Added!");
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Age} Added!");
        }
    }

    //kendi attributemizi yazma
    //attribute için kullanım yeri ayarlama
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple =true)]
    class RequiredPropertyAttribute:Attribute
    {

    }

    //kendi attributemizi yazma(parametreli) constructor kullanarak
    [AttributeUsage(AttributeTargets.Class , AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
