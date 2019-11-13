using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eximo.core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Contact ContactInformation { get; set; }
        public PaymentInfo Payment { get; set; }
        public ServicePlan Plan { get; set; }
        public IList<AuthorizationType> Authorizations { get; set; }
        public IList<DataBroker> Databrokers { get; set; }
        public IList<EmailMarketing>  EmailMarketings { get; set; }
        public IList<Notification> Notifications { get; set; }

    }
}
