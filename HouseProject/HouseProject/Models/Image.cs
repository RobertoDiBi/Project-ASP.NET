using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HouseProject.Models
{
    public class Image
    {
        public int ID { get; set; }

        [Column(TypeName = "varbinary")]
        public byte[] HouseImage { get; set; }
    }
}