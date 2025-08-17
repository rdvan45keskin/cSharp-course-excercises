using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for döngüsü
            //for (int i = 0; i <= 100; i += 2)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("bitti");


            //while döngüsü
            //int number = 100;
            //while (number>=0) 
            //{
            //    Console.WriteLine(number);
            //    number--;
            //}
            //Console.WriteLine("now number is {0}",number);


            //do-while döngüsü
            //int number = 10;
            //do
            //{
            //    Console.WriteLine(number);
            //    number--;
            //}
            //while (number>=11);


            //forEach döngüsü
            //string[] students = new string[2] { "Engin", "Selo" };
            //foreach (var item in students)
            //{
            //    Console.WriteLine(item);
            //}


            //asal mı fonksiyonu
            var sayi = 8;
            Console.WriteLine(isPrimeNumber(sayi));
            if (isPrimeNumber(sayi))
            {
                Console.WriteLine("bu bir asal sayidir");
            }
            else { Console.WriteLine("bu bir çift sayi değildir"); }
        }

        private static bool isPrimeNumber(int number)
        {
            bool result = true;
            for (int i = 2; i < number - 1; i++) 
            {
                if (number % i == 0) 
                {
                    result = false; 
                    break;
                }
            }
            return result;
        }
    }
}