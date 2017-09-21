using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamManagement.Models;

namespace TeamManagement.ViewModels
{
    public class LayoutViewModels
    {
        public ApplicationUser CurrentUser { get; set; }

        public List<GameScheduleModels> GameSchedule { get; set; }
    }
}