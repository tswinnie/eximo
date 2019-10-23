using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class EmailMarketing
    {
        public int EmailMarketingId { get; set; }
        public string MarketerName { get; set; }
        public string Website { get; set; }
        public Status EmailMarketingStatus { get; set; }

        //foregin key
        public int UserId { get; set; }
    }
}
