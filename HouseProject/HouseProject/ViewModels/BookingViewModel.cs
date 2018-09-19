using HouseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseProject.ViewModels
{
    public class BookingViewModel
    {
        public Home Home { get; set; }
        public BookingRecord bookingRecord { get; set; }
    }
}