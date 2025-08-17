using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Add();
            //var result = Add2(20);
            //Console.WriteLine(result);
            //int num1 = 20;
            //int num2 = 100;
            //var result2 = Add3(ref num1,num2);
            //Console.WriteLine(result2);
            //Console.WriteLine(num1);

            Console.WriteLine(Multiply(2, 4, 6));

            Console.WriteLine(Add4(1,2,3,4,5,6,7,8,9));

        }
        static void Add()
        {
            Console.WriteLine("Added!");
        }

        static int Add2(int num1, int num2=30)
        {
            return num1 + num2;
        }

        static int Add3(ref int num1,int num2)
        {
            num1 = 30;
            return num1 + num2;
        }

        static int Multiply(int num1,int num2)
        {
            return (num1 * num2);
        }

        static int Multiply(int num1, int num2 ,int num3)
        {
            return (num1 * num2 * num3);
        }

        static int Add4(params int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
