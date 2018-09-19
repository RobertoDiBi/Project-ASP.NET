using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseProject.Models
{
    public class HouseImage
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }

        public Home Home { get; set; }
        public int HomeID { get; set; }

        public bool IsMainImage { get; set; }
    }
}