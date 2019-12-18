using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.Models.ServicePlan
{
    public class Plan
    {
        public string PlanTitle { get; set; }
        public string PlanPrice { get; set; }
        public List<Feature> PlanFeatures { get; set; }

    }
}
