﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class ApplicationModels
    {
        public int Id { get; set; }

        public ApplicationUser AspNetUsers { get; set; }

        public string AspNetUsersId { get; set; }

        [Display(Name = "Application Date")]
        public DateTime ApplicationDate { get; set; }
    }
}