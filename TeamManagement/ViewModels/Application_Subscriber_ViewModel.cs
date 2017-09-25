using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamManagement.Models;

namespace TeamManagement.ViewModels
{
    public class Application_Subscriber_ViewModel
    {
        public ApplicationModels ApplicationModel { get; set; }

        public IEnumerable<ApplicationModels> Applications { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<ApplicationUser> User { get; set; }
    }
}