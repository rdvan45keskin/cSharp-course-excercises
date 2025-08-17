using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new SqlServer();
            database.Add();
            database.Delete();

            Database database2 = new Oracle();
            database2.Add();
            database2.Delete();
        }

        abstract class Database
        {
            public void Add() {
                Console.WriteLine("Added by default");
            }

            public abstract void Delete();
        }

        class SqlServer : Database
        {
            public override void Delete()
            {
                Console.WriteLine("Deleted by Sql");
            }
        }

        class Oracle : Database
        {
            public override void Delete()
            {
                Console.WriteLine("Deleted by Oracle");
            }
        }
    }
}
