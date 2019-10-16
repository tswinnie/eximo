using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Contact ContactInformation { get; set; }
        public PaymentType Payment { get; set; }
        public ServicePlan Plan { get; set; }
        public AuthorizationType Authorization { get; set; }
        public List<DataBroker> DataBrokers { get; set; }
        public List<MailMarketing> MailMarketings { get; set; }
        public List<EmailMarketing> EmailMarketings { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
