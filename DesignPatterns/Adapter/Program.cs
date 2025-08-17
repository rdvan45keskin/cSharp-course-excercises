using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager xproductManager = new ProductManager(new XLogger());
            ProductManager yproductManager = new ProductManager(new YLoggerAdapter());
            yproductManager.Save();
        }
    }

    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save() 
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved"); 
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class XLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logged with XLogger, {message}");
        }
    }

    //BUNUN ICINI DEISTIREMIOZ DIYE DUSUNCEZ
    class YLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logged with YLogger, {message}");
        }
    }

    //YLoggeri adapter adında başka classla sarıp çağırıyoz
    class YLoggerAdapter : ILogger
    {
        public void Log(string message)
        {
            YLogger yLogger = new YLogger();
            yLogger.Log(message);
        }
    }
}
