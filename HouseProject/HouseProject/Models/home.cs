using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseProject.Models
{
    public class Home
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public HomeType HomeType { get; set; }
        [Display(Name = "Home type")]
        public int HomeTypeID { get; set; }

        [Range(1, 100)] [Display(Name = "Number of rooms")]
        public int NumOfRooms { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required] [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Invalid postal code. Use all capital letters please.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required][Range(1, 100)][Display(Name = "Max occupants")]
        public int MaxOccupants { get; set; }

        public List<SelectedAmenity> Amenities { get; set; }
        public List<int> AmenitiesIDs { get; set; }

        [Required][Range(1, double.MaxValue, ErrorMessage = "Price cannot be free or negative.")]
        [Display(Name = "Price per night")]
        public double PricePerNight { get; set; }
        
        public bool Approved { get; set; } = false;

        public List<Image> Images { get; set; }
        public List<int> ImageIDs { get; set; }
    }
}