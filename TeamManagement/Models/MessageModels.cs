using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class MessageModels
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Display(Name = "Message Recepient")]
        public int UserId { get; set; }

    }
}