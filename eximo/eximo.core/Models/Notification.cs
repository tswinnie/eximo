using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eximo.core.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationCompleted { get; set; }

        //foregin key
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
