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

        public ApplicationUser AspNetUsers { get; set; }


        [Display(Name = "Message Recepient")]
        public string AspNetUsersId { get; set; }

    }
}