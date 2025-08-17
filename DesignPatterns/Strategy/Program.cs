using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    //50 tane if yazmak yerine bunu kullanıoz
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.creditCalculatorBase= new NewPersonCreditCalculator();
            customerManager.SaveCredit();

            customerManager.creditCalculatorBase = new OldPersonCreditCalculator();
            customerManager.SaveCredit();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class NewPersonCreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using newPerson");
        }
    }

    class OldPersonCreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using oldPerson");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase creditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            creditCalculatorBase.Calculate();
        }
    }
}
