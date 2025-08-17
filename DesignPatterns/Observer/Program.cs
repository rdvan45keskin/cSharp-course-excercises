using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    //bir şey olursa başka bir şeyi tetikleme
    //ürün indirime girerse haber verme gibi
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            var employeeObserver = new EmployeeObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(employeeObserver);
            productManager.Detech(customerObserver);

            productManager.UpdatePrice();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }
        //observer ekleme
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }
        //observeri çıkarma
        public void Detech(Observer observer)
        {
            _observers.Remove(observer);
        }
        //değişiklikleri bildirme
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price has been changed");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price has been changed");
        }
    }
}
