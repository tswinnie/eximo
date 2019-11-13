using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public class EmailMarketing
    {
        [Key]
        public int EmailMarketingId { get; set; }
        public string MarketerName { get; set; }
        public string Website { get; set; }
        public Status EmailMarketingStatus { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
