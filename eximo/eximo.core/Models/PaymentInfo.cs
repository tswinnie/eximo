using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class PaymentInfo
    {
        public int PaymentId { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public string CardType { get; set; }
        public int SecurityNumber { get; set; }

        //foregin key
        public int UserId { get; set; }

    }
}
