using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamManagement.Models;

namespace TeamManagement.ViewModels
{
    public class TrackingViewModels
    {
        public ApplicationUser Players { get; set; }

        public ApplicationUser AspNetUser { get; set; }

        public IEnumerable<ApplicationUser> Player { get; set; }

        public TrackingModels Tracking { get; set; }

        public IEnumerable<TrackingModels> Track { get; set; }

        public RatingModels Ratings { get; set; }

        public IEnumerable<RatingModels> Rate { get; set; }
    }
}