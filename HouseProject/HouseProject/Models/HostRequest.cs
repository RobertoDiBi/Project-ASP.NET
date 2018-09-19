using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseProject.Models
{
    public class HostRequest
    {
        public int ID { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        public Home Home { get; set; }
        public int HomeID { get; set; }

        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; } = "Pending";
    }
}