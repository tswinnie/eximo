using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public class ServicePlan
    {
        [Key]
        public int ServicePlanId { get; set; }
        public string ServiceName { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
