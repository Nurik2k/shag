using System;
using System.Collections.Generic;
using System.Text;

namespace ls4
{
    internal class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public Address(string Country, string Cite, string Street, string House)
        {
            this.Country = Country;
            this.City = City;
            this.Street = Street;
            this.House = House;
        }
    }
}
