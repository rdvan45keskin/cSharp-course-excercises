using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
    //çalışma anında olaylara müdahale etme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2,3);
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3, 4));


            //**çalışma anında instance üretme**
            var type = typeof(DortIslem);
            //gelen tipe göre newleme
            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,10,5);     //DortIslem dortIslem = new DortIslem(2,3); ikisi aynı şey
            //Console.WriteLine(dortIslem.Topla(4, 5));
            //Console.WriteLine(dortIslem.Topla2());

            var instance = (DortIslem)Activator.CreateInstance(type, 10, 5);
            //GetMethod ile methoda ulaşıp Invoke ile o methodu calıstırma
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");     //methodun bilgisini döndürme
            var result = methodInfo.Invoke(instance,null);      //instancenin methodInfosunu calıstır
            Console.WriteLine(result);
            Console.WriteLine("-------------------");
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"Method Adı : {method.Name}");
                foreach (var parameter in method.GetParameters()) 
                { 
                    Console.WriteLine($"Parametre : {parameter.Name}");
                }
                Console.WriteLine("-------------------");
                foreach (var attribute in method.GetCustomAttributes())
                {
                    Console.WriteLine($"Attribute : {attribute.GetType().Name}");
                }
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-");
            }
        }
    }

    public class DortIslem
    {
        int _sayi1;
        int _sayi2;
        public DortIslem(int sayi1,int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }


        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }

    public class MethodNameAttribute : Attribute
    {
        string _name;
        public MethodNameAttribute(string name)
        {
            _name = name;
        }
    }
}
