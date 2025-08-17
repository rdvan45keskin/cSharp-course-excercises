using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<String> result = utilities.BuildList<string>("Ankara","Izmir","Istanbul");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> customers = utilities.BuildList<Customer>(new Customer { FirstName = "Nicat" }, new Customer { FirstName = "Selo" });
            foreach (var customer in customers) 
            {
                Console.WriteLine($"Customer {customer.FirstName}");
            }
        }
    }

    class Utilities 
    {
        public List<T> BuildList<T>(params T[] items) 
        {
            return new List<T>(items);
        }
    }

    //değişken verip interfaceyi değişken yapma
    //where ile T nin ne olacağını ayarlıyoz
    //referans tip olmalı,IEntityden Implement edilmeli ve newlenebilir(constructor) olmalı
    interface IRepository<T> where T : class, IEntity, new()//struct yazarsak değer tipler(Int vb.) kabul edilecekti
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    interface IEntity
    {
    
    }

    class Product:IEntity
    {
        
    }

    interface IProductDal : IRepository<Product>
    {

    }

    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    //**********************************//

    class Customer:IEntity
    {
        public string FirstName { get; set; }
    }

    interface ICustomerDal : IRepository<Customer>
    {
        void Custom();
    }

    class CustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Custom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
