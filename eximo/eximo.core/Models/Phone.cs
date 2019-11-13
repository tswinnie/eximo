using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        public int AreaCode { get; set; }
        public int PhoneNumber { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
