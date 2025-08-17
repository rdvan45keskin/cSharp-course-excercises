using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();
            //TryCatch();
            //ActionDemo();
            //değer1 değer2 dönüş tipi
            Func<int, int, int> add = Topla;
            Console.WriteLine(add(3,5));

            //parametresiz methodlardan int döndürüyo
            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1,100);
            };
            Console.WriteLine(getRandomNumber());

            Thread.Sleep(1000);
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            Console.WriteLine(getRandomNumber2());



        }
        private static void TryCatch() 
        {
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private static void ActionDemo() 
        {
            //action ile hata yakalama
            //gönderilen methodun karşılığı, yazılacak kodlar
            //sürekli try catch yapmak yerine 1 kere yapıp fonksiyonları ona yollama
            HandleExceptipn(() =>
            {
                Find();
            });
        }

        private static void HandleExceptipn(Action action)//action denen şey yukarıdaki find fonksiyonu
        {
            try
            {
                action.Invoke();    //fonksiyonu çalıştırma
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
        }

        private static void ExceptionIntro() 
        {
            try
            {
                string[] students = { "Engin", "Derin", "Salih" };
                students[3] = "Ahmet";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! {0}", e.Message);
            }
        }

        private static void Find() 
        {
            List<string> students = new List<string> { "Engin", "Derin", "Salih" };
            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record Not Found");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }
    }
}
