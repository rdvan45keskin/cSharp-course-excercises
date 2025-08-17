using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = new string[2] { "Engin", "Selo" };
            //students[0] = "engin";
            //students[1] = "selo";

            string[] students2 = {"Engin","Selo"};


            string[,] regions = new string[7, 3]
            {
                {"a","b","c"},
                {"d","e","f"},
                {"g","h","i"},
                {"j","k","l"},
                {"m","n","o"},
                {"p","r","s"},
                {"v","y","z"}
            };

            for (int i = 0; i <= regions.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= regions.GetUpperBound(1); j++)
                {
                    Console.WriteLine(regions[i, j]);
                }
                Console.WriteLine("************");
            }

            Console.WriteLine(regions[1,2]);    //f
        }
    }
}
