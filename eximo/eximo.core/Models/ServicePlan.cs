using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class ServicePlan
    {

        public int ServicePlanId { get; set; }
        public string ServiceName { get; set; }

        //foregin key
        public int UserId { get; set; }
    }
}
