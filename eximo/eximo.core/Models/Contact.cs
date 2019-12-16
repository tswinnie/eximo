using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public Phone PhoneNumber { get; set; }
        public Address ContactAddress { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }



    }
}
