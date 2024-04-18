using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDB
{
    class Supplier
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public Supplier(string name, string phoneNum, string address, string city, string country)
        {
            Name = name;
            PhoneNumber = phoneNum;
            Address = address;
            City = city;
            Country = country;
        }

    }
}
