using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamManagement.Models;

namespace TeamManagement.ViewModels
{
    public class AttendanceViewModel
    {
        public List<ApplicationUser> Players { get; set; }

        public List<GameScheduleModels> GameSchedule { get; set; }
    }
}