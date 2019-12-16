using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public class PaymentInfo
    {
        [Key]
        public int PaymentId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public int SecurityNumber { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
