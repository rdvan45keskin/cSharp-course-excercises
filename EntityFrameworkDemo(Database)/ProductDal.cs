using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo_Database_
{
    public class ProductDal
    {
        public List<Product> GetAll() 
        {
            //optimizasyon için using kullanılıyomuş komut bittiği gibi kullanılan nesneleri atıyo
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }

        //LINQ isme göre arama
        public List<Product> GetByName(string key)
        {
            //isme göre arama yapma
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        //LINQ fiyata göre arama
        public List<Product> GetByUnitPrice(decimal price)
        {
            //isme göre arama yapma
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();
            }
        }

        //LINQ belli fiyat aralığını arama
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            //isme göre arama yapma
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=min && p.UnitPrice<=max).ToList();
            }
        }

        //LINQ idye göre getirme. bulursa getir bulamazsa null getir
        public Product GetById(int id)
        {
            //optimizasyon için using kullanılıyomuş komut bittiği gibi kullanılan nesneleri atıyo
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Products.SingleOrDefault(p=>p.Id==id);
                return result;
            }
        }

        //ürün ekleme
        public void Add(Product product) 
        {
            using (ETradeContext context = new ETradeContext())
            {
                //gönderilen product nesnesini Products tablosuna ekle
                context.Products.Add(product);
                //değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        //ürün güncelleme
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //gönderilen product nesnesini Products tablosu ile eşliyo
                var entity = context.Entry(product);
                //işaretlenen entity nesnesini güncellendi olarak işaretleme
                entity.State = EntityState.Modified;
                //değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        //ürün silme
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //gönderilen product nesnesini Products tablosu ile eşliyo
                var entity = context.Entry(product);
                //işaretlenen entity nesnesini güncellendi olarak işaretleme
                entity.State = EntityState.Deleted;
                //değişiklikleri kaydet
                context.SaveChanges();
            }
        }


    }
}
