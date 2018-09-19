using HouseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseProject.ViewModels
{
    public class ManageRequestsViewModel
    {
        public IEnumerable<HostRequest> HostRequests { get; set; }
        public IEnumerable<Home> Homes { get; set; }
        public IEnumerable<HomeType> HomeTypes { get; set; }
    }
}