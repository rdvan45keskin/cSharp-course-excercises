using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

        }
    }
    public abstract class Logging 
    {
        public abstract void Log(string message);
    }

    public class XLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with XLogger");
        }
    }

    public class YLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with YLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class XCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with XCache");
        }
    }

    public class YCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with YCache");
        }
    }
    //ana fabrika
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    //yancı fabrika1
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new XLogger();
        }

        public override Caching CreateCaching()
        {
            return new XCache();
        }
    }
    //yancı fabrika2
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new YLogger();
        }

        public override Caching CreateCaching()
        {
            return new YCache();
        }
    }

    public class ProductManager
    {
        CrossCuttingConcernsFactory _cccFactory;
        Logging _logging;
        Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory cccFactory)
        {
            _cccFactory = cccFactory;
            _logging = _cccFactory.CreateLogger();
            _caching = _cccFactory.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log("");
            _caching.Cache("");
            Console.WriteLine("Product Listed!");
        }
    }
}
