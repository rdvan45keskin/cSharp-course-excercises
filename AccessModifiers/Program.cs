using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //protectedin privateden farkı
            //inheritance edilen sınıflarda kullanılabiliyor
            //private
            //protected
            //internal
        }

        class Customer
        {
            private int id { get; set; }
            protected int id2 { get; set; }
            public void Save()
            {

            }
        }

        class Student : Customer
        {
            public void Save2()
            {
                id2 = 1;
                Console.WriteLine();
            }
        }

        public class Course 
        {
            public string Name { get; set; }
        }
    }
}
