using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    //constructor
    internal class Customer
    {
        public int Id { get; set; }
        //encapsulation değeri okurken değişiklik yapmak istersek yapılan şey
        private string _firstName;
        //nadiren böyle yapılıyomuş
        public string FirstName { 
            get 
            {
                return "Mr. " + _firstName;
            } 
            set 
            {
                _firstName = value;    
            } 
        }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
