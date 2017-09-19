using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class AlertModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Alert Message")]
        public string AlertMessage { get; set; }

        public int UserId { get; set; }
    }
}