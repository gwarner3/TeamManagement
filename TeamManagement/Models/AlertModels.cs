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

        public ApplicationUser AspNetUsers { get; set; }

        public string AspNetUsersId { get; set; }

        public IEnumerable<AlertModels> Alerts { get; set; }

        public string DateSent { get; set; }

        public DateTime? GameDate { get; set; }

        public bool Received { get; set; }
    }
}