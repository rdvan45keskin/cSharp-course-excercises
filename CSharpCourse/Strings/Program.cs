using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string city = "Manisa";
            ////Console.WriteLine(city[0]);

            //foreach (var item in city)
            //{
            //    Console.WriteLine(item);
            //}

            //string city2 = "istanbul";
            //string result = city +" "+city2;
            //Console.WriteLine(result);
            //Console.WriteLine(String.Format("{0} {1}", city, city2));

            string sentence = "My name is Nicat Isler";
            var result = sentence.Length;
            var result2 = sentence.Clone();
            //sentence = "My name is Selo";

            var result3 = sentence.EndsWith("r");//r ile mi bitio
            var result4 = sentence.StartsWith("M");//m ile mi başlıo
            var result5 = sentence.IndexOf("name");//bulunduğu indexi söylüyo
            var result6 = sentence.IndexOf(" ");//ilk bulduuğu şeyi verio
            var result7 = sentence.LastIndexOf(" ");//sondan başlıyo
            var result8 = sentence.Insert(0, "Hello ");//0. indexe verilen metni yerleştir
            var result9 = sentence.Substring(3,4);//3. laralterden 4 karakter al
            var result10 = sentence.ToUpper();//hepsini büyük harf yap
            var result11 = sentence.ToLower();//hepsini küçük harf yap
            var result12 = sentence.Replace(" ","-");//boşluk yerine - koy
            var result13 = sentence.Remove(2,5);//2. indexten itibaren 5 index kaldır
            Console.WriteLine(result13);
        }
    }
}
