using HouseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseProject.ViewModels
{
    public class HouseViewModel
    {

        public IEnumerable<Home> Homes { get; set; }
        public IEnumerable<HomeType> HomeTypes { get; set; }
        public List<Amenity> Amenities { get; set; }
    }
}