using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    //test etmek için hiçbir şey yapmayan bir test nesnesi yollama
    //Singleton deseni kullanıyor
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }

    public class CustomerManager
    {
        ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    class XLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with XLogger");
        }
    }

    class YLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with YLogger");
        }
    }

    class StubLogger : ILogger
    {

        //Singleton Deseni
        private static StubLogger _instance = new StubLogger();
        private static object _instanceLock = new object();

        private StubLogger() { }

        public static StubLogger GetLogger()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new StubLogger();
                }
            }
            return _instance;
        }
        public void Log()
        {
            
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }
}
