using System;

namespace Singleton
//1 kere newlemeyi kontrol etmeye yarıyo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.createAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _locker = new object();

        private CustomerManager()
        {

        }

        public static CustomerManager createAsSingleton()
        {
            lock (_locker) 
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!!");
        }
    }
}
