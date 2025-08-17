using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesAndVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Value Types
            //Console.WriteLine("Hello World");
            char character = 'a';
            bool condition = true;
            byte number4 = 255; //0-255 arası
            short number3 = 32767;
            int number1 = 2147483647;
            long number2 = 9223372036854775807;
            double number5 = 10.4;
            decimal number6 = 1.1m;
            var number7 = 10;//var int oluyo burda 10 olduğu için
            
            
            Console.WriteLine("Number1 is {0}",number1);
            Console.WriteLine("Number2 is {0}", number2);
            Console.WriteLine("Number3 is {0}", number3);
            Console.WriteLine("Number4 is {0}", number4);
            Console.WriteLine("Number5 is {0}", number5);
            Console.WriteLine("Number6 is {0}", number6);
            Console.WriteLine("Character is : {0}",character);
            Console.WriteLine(Days.Friday);
            Console.ReadLine();
        }
    }

    enum Days {
        Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday
    }
}
