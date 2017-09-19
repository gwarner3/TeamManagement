using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class RatingModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Player Rating")]
        public int Rating { get; set; }

        [Display(Name = "Player")]
        public int  UserId { get; set; }
    }
}