using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class GameScheduleModels
    {
        public int Id { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Game Date")]
        public DateTime GameDate { get; set; }

        [Required]
        [Display(Name = "Game Time")]
        public DateTime GameTime { get; set; }

        [Required]
        [Display(Name = "Opponent")]
        public string Opponent { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip")]
        public int Zip { get; set; }
        [NotMapped]
        public string DisplayName {
            get { return EventName + " " + GameDate; }
            set { DisplayName = value; }
        }
        
    }
}