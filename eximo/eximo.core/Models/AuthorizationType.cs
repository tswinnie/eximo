using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.core.Models
{
    public class AuthorizationType
    {
        public int AuthorizationId { get; set; }
        public string AuthorizationName { get; set; }
        public bool AuthorizationActive { get; set; }

        //foregin key
        public int UserId { get; set; }
    }
}
