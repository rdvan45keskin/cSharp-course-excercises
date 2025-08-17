using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();
        }
    }

    public class LoggerFactory:ILoggerFactory 
    {
        public ILogger CreateLogger()
        {
            return new XLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new YLogger();
        }
    }

    public class XLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with XLogger");
        }
    }

    public class YLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YLogger");
        }
    }

    public class CustomerManager 
    {
        private ILoggerFactory _logger;
        public CustomerManager(ILoggerFactory logger)
        {
            _logger = logger;
        }
        public void Save() 
        {
            Console.WriteLine("Saved");
            ILogger logger = _logger.CreateLogger();
            logger.Log();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
}
