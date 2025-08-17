using System;

namespace ReferenceAndValueType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Değer(Value type)
            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30;

            Console.WriteLine(number2);

            //Referans
            string[] cities1 = { "Ankara", "Adana", "Amasya" };
            string[] cities2 = { "Bursa", "Bolu", "Balıkesir" };

            cities2 = cities1;
            Console.WriteLine(cities2[0]);
        }
    }
}
