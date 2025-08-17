using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    //Hiyerarsi kurmak için kullanılır
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee { Name = "Engin Demiroğ" };
            Employee nicat = new Employee { Name = "Nicat Isler" };

            nicat.AddSubordinate(engin);

            Employee musa = new Employee { Name = "Musa Y." };
            nicat.AddSubordinate(musa);

            Contractor Xperson = new Contractor { Name = "X" };
            musa.AddSubordinate(Xperson);

            Employee selo = new Employee { Name = "selo" };

            musa.AddSubordinate(selo);

            Console.WriteLine(nicat.Name);
            foreach (Employee manager in nicat)
            {
                Console.WriteLine($"  {manager.Name}");
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine($"    {employee.Name}");
                }
            }

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person) 
        {
            _subordinates.Add(person);
        }
        //
        public void RemoveSubordinate(IPerson person) 
        {
            _subordinates.Remove(person);
        }
        //
        public IPerson GetSubordinate(int index) 
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
