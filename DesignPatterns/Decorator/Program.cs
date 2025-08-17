using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    //lojik işlemlerde indirim yapma vs işe yarıo
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar {Make = "BMW", Model = "3.20", RentPrice = 2500};
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine($"Concrete : {personalCar.RentPrice}");
            Console.WriteLine($"Special offer : {specialOffer.RentPrice}");
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal RentPrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal RentPrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal RentPrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        private readonly CarBase _carBase;
        public int DiscountPercentage { get; set; }
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal RentPrice 
        { 
            get 
            {
                return _carBase.RentPrice-_carBase.RentPrice*DiscountPercentage/100;
            }
            set 
            {
                
            }
        }
    }
}
