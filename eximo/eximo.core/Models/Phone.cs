using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int AreaCode { get; set; }
        public int PhoneNumber { get; set; }

        //foregin key
        public int UserId { get; set; }

    }
}
