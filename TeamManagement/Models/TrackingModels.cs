using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class TrackingModels
    {
        public int Id { get; set; }

        public string AspNetUsersId { get; set; }

        public string PlayerId { get; set; }
    }
}