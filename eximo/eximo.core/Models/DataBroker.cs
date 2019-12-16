using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public enum Status
    {
        Active,
        Inactive,
        Pending
    }

    public enum CapturedCustomerData
    {
        Name,
        Email,
        Address,
        Phone
    }

    public class DataBroker
    {
        [Key]
        public int DataBrokerId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string VerificationType { get; set; }
        public string OptOutLink { get; set; }
        public string Bio { get; set; }
        public CapturedCustomerData CaptureCustomerInfo { get; set; }
        public Status CustomerAccountStatus { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
