using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using TeamManagement.Models;

namespace TeamManagement.ViewModels
{
    public class GameScheduleModelWithLatLong
    {
        public string Lat { get; set; }

        public string Long { get; set; }

        public GameScheduleModels GameScheduleWithLatLong { get; set; }
    }
}