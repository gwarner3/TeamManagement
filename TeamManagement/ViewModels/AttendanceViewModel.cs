using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.ViewModels
{
    public class AttendanceViewModel
    {
        public List<ApplicationUser> Players { get; set; }

        public IEnumerable<GameScheduleModels> GameScheduleModels { get; set; }

        public AttendanceModels AttendanceModels { get; set; }
    
    }
}