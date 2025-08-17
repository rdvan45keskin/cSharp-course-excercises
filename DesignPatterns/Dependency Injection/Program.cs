using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    //katmanlar arası geçiş yaparken bağımlılıkları azaltmaya yarıyor
    internal class Program
    {
        static void Main(string[] args)
        {
            //IOC Container
            IKernel kernel = new StandardKernel();
            //IProductDal türünde bi istek gelirse EfProductDal gönder demek oluyo
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();

        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal:IProductDal
    {
        public void Save() 
        {
            Console.WriteLine("Saved with EntityFramework");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NHibernate");
        }
    }

    class ProductManager
    {
        //dependency Injection burası
        //----
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //----
        public void Save()
        {
            
            _productDal.Save();
        }
    }


}
