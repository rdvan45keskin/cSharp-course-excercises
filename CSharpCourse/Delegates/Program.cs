using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //elçi atama void döndüren ve parametre almayan operasyonlara elçilik yapma
    public delegate void MyDelegate();
    public delegate void MyDelegate2(string text);

    //return type var ise en son return olan şey gelir
    public delegate int MyDelegate3(int number1,int number2);
    internal class Program
    {
        /*
         * 
         * 
         *      Action ve Func methodlarının anlatımı Exceptions da anlatılıyo
         * 
         * 
         */
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;    //hello
            myDelegate += customerManager.ShowAlert;                //hello + alert dedik
            myDelegate-= customerManager.SendMessage;               //mesajı çıkar
            myDelegate();

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("hello");

            Mathematic mathematic = new Mathematic();
            MyDelegate3 myDelegate3 = mathematic.Topla;
            myDelegate3 += mathematic.Carp;
            var sonuc = myDelegate3(2,3);
            Console.WriteLine(sonuc);
        }
    }

    public class CustomerManager
    { 
        public void SendMessage() 
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Alert!");      
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    class Mathematic
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
