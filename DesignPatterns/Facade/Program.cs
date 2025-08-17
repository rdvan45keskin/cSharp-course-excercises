using System;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validate");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }

    class CustomerManager
    {
        CrossCuttingConcernsFacade _concerns;
        public CustomerManager() 
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save() 
        {
            _concerns.caching.Cache();
            _concerns.logging.Log();
            _concerns.authorize.CheckUser();
            _concerns.validate.Validate();
            Console.WriteLine("Saved!!!!!");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging logging;
        public ICaching caching;
        public IAuthorize authorize;
        public IValidate validate;

        public CrossCuttingConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
            validate = new Validation();
        }
    }
}
