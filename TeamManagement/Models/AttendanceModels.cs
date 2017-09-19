using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class AttendanceModels
    {
        public int Id { get; set; }

        [Display(Name = "Player")]
        public int UserId { get; set; }

        [Display(Name = "Absence Date")]
        public DateTime AbsentDate { get; set; }

        public string Event { get; set; }

    }
}