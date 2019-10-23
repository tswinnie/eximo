using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalZip { get; set; }

        //foregin key
        public int UserId { get; set; }

    }
}
