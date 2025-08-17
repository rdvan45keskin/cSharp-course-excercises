using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2_OOP_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.logger = new SmsLogger();
            customerManager.Add();

            //ILogger türünde dizi elemanları oluşturduk
            ILogger[] loggers = new ILogger[]
            {
                new SmsLogger(),
                new DatabaseLogger(),
                new FileLogger(),
            };
            Console.WriteLine("------ Multiple Loggers ------");
            foreach (var logger in loggers) 
            {
                customerManager.logger = logger;
                customerManager.Add();
            }
        }

        class CustomerManager
        {
            public ILogger logger { get; set; }
            public void Add() 
            {
                logger.Log();
                Console.WriteLine("Customer Added!");
            }
        }

        class DatabaseLogger:ILogger 
        {
            public void Log() 
            { 
                Console.WriteLine("Logged to Database!");
            }
        }

        class FileLogger : ILogger
        {
            public void Log() 
            {
                Console.WriteLine("Logged to File!");
            }
        }

        class SmsLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged with Sms!");
            }
        }

        interface ILogger
        {
            void Log();
        }
    }
}
