using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //TypeSafeArrayList();
            Dictionary();


        }

        private static void ArrayList()

        {
            ArrayList cites = new ArrayList();
            cites.Add("Ankara");
            cites.Add("Adana");
            cites.Add(9);
            cites.Add("Istanbul");

            foreach (var item in cites)
            {
                Console.WriteLine(item);
            }
        }

        private static void TypeSafeArrayList()
        {
            List<string> cities = new List<string>();
            cities.Add("Manisa");
            cities.Add("Izmir");

            Console.WriteLine(cities.Contains("Manisa"));   //dizinin içinde item varsa true döner

            foreach (var item in cities)
            {
                Console.WriteLine(item); 
            }

            Console.WriteLine("------ Customers ------");


            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id = 1, Name = "Nicat", Address = "Azerbaycan" });
            //customers.Add(new Customer { Id = 2, Name = "Selo", Address = "Turkey" });

            List<Customer> customers = new List<Customer> 
            {
                new Customer { Id = 1, Name = "Nicat", Address = "Azerbaycan" },
                new Customer { Id = 2, Name = "Selo", Address = "Turkey" }
            };

            var customer = new Customer
            {
                Id = 3,
                Name = "Indigo",
                Address = "Turkey"
            };
            customers.Add(customer);                    //listeye eleman ekleme
            customers.AddRange(new Customer[2]          //bir listeyi eklemeye yarar
            {
                new Customer{ Id = 4, Name = "Tsukasavan", Address = "Turkey" },
                new Customer{ Id = 5, Name = "BeletBrath", Address = "Turkey" }
            });
            ///customers.Clear();                          //listenin elemanlarını temizler
            Console.WriteLine(customers.Contains(new Customer {Id=1,Name="Nicat",Address="Azerbaycan"}));   //referansa baktığı için false döner
            Console.WriteLine(customers.Contains(customer));   //customer diye bir referans olduğu için true döner
            var index = customers.IndexOf(customer);     //elemanın kaçıncı sırada olduğunu verir
            Console.WriteLine("index : {0}",index);

            customers.Add(customer);

            var reverseIndex = customers.LastIndexOf(customer); //sondan başlayarak arama yapıyo
            Console.WriteLine("index : {0}", reverseIndex);

            customers.Insert(0, customer);              //istenilen indexe istenilen değeri ekler

            customers.Remove(customer);                 //bulduğu ilk değeri kaldırır

            customers.RemoveAll(c=>c.Name=="Indigo");   //bulduğu tüm değerleri siler
            foreach (var item in customers)
            {
                Console.WriteLine(item.Name);
            }
            var count = customers.Count;                //listedeki eleman sayısın alır
            Console.WriteLine("Count : {0}", count);
        }

        private static void Dictionary() 
        {
            Dictionary<string,string> dictionary = new Dictionary<string,string>();
            dictionary.Add("Book","Kitap");
            dictionary.Add("Pencil", "Kalem");
            dictionary.Add("Computer", "Bilgisayar");

            Console.WriteLine(dictionary["Pencil"]);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key+" : "+item.Value);
            }

            dictionary.ContainsKey("glass");        //dictionaryde böyle bir key var mı
            dictionary.ContainsValue("Kalem");      //dictionaryde böyle bir value var mı
        }
    }

    class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
