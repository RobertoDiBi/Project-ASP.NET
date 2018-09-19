using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseProject.Models
{
    public class BookingRecord
    {
        public int ID { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        public Home Home { get; set; }
        public int HomeID { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Total")]
        public double TotalPrice { get; set; }
    }
}