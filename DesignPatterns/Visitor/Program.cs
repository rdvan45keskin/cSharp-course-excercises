using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        //herkese aynı anda işlem yapmaya yarıyo
        static void Main(string[] args)
        {
            Manager nicat = new Manager {Name = "Nicat" , Salary = 50000};
            Manager engin = new Manager { Name = "Engin", Salary = 30000 };

            Worker selo = new Worker {Name = "Selo" , Salary = 1000 };
            Worker musa = new Worker { Name = "Musa", Salary = 300 };
            Worker ehucu = new Worker { Name = "Ehucu", Salary = 4000 };

            nicat.Subordinates.Add(engin);
            engin.Subordinates.Add(selo);
            engin.Subordinates.Add(musa);
            engin.Subordinates.Add(ehucu);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(nicat);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayRiseVisitor payRiseVisitor = new PayRiseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payRiseVisitor);


        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager() 
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    //ödeme yapma
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} paid {worker.Salary}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} paid {manager.Salary}");
        }
    }
    //maaş arttırma
    class PayRiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} salary increased to {worker.Salary * (decimal)1.1}");

        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} salary increased {manager.Salary * (decimal)1.2}");

        }
    }
}
