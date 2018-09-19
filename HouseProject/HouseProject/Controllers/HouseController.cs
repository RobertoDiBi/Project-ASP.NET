using HouseProject.Models;
using HouseProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HouseProject.Controllers
{
    public class HouseController : Controller
    {
        //DBContext Object
        private ApplicationDbContext _context;

        //class constructor
        public HouseController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: House
        public ActionResult Index(string SearchString, string sort, HouseViewModel model)
        {

            var houses = _context.Homes.Include(a => a.Amenities).Where(m => m.Approved == true);

            ViewBag.SortByTitle = string.IsNullOrEmpty(sort) ? "title" : "";
            ViewBag.SortByProvince = sort == "province" || sort=="" ? "province" : "province";
            ViewBag.SortByPriceLow = sort == "price_low" || sort == "" ? "price_low" : "price_low";
            ViewBag.SortByPriceHigh = sort == "price_high" || sort == "" ? "price_high" : "price_high";

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                //LINQ Code
                houses = (from c in houses
                             where c.City.ToLower().StartsWith(SearchString.ToLower())
                             select c);
                ViewBag.search = SearchString;
            }

            switch (sort)
            {
                case "title":
                    houses = houses.OrderBy(c => c.Title);
                    break;
                case "province":
                    houses = houses.OrderBy(c => c.Province);
                    break;
                case "price_low":
                    houses = houses.OrderBy(c => c.PricePerNight);
                    break;
                case "price_high":
                    houses = houses.OrderByDescending(c => c.PricePerNight);
                    break;
            }
            var viewModel = new HouseViewModel
            {
                Homes = houses,
                HomeTypes = _context.HomeTypes.ToList(),
                Amenities = _context.Amenities.ToList()
            };
            return View(viewModel);
        }

        //display house details

        public ActionResult HouseDetails(int ID)
        {
            var house = _context.Homes.Include(m => m.Amenities).Include(i => i.Images).Where(m=>m.ID==ID).SingleOrDefault();
            if (house == null)
                return HttpNotFound();
            else
                return View("Details",house);
        }

        [Authorize]
        public ActionResult RequestHost()
        {
            var viewModel = new HostRequestViewModel
            {
                Home = new Home(),
                HomeTypes = _context.HomeTypes.ToList(),
                Amenities = _context.Amenities.ToList()
            };

            List<SelectListItem> provinces = new List<SelectListItem>();
            provinces.Add(new SelectListItem { Text = "Alberta", Value = "Alberta" });
            provinces.Add(new SelectListItem { Text = "British Columbia", Value = "British Columbia" });
            provinces.Add(new SelectListItem { Text = "Manitoba", Value = "Manitoba" });
            provinces.Add(new SelectListItem { Text = "New Brunswick", Value = "New Brunswick" });
            provinces.Add(new SelectListItem { Text = "Newfoundland and Labrador", Value = "Newfoundland and Labrador" });
            provinces.Add(new SelectListItem { Text = "Nova Scotia", Value = "Nova Scotia" });
            provinces.Add(new SelectListItem { Text = "Ontario", Value = "Ontario" });
            provinces.Add(new SelectListItem { Text = "P.E.I", Value = "Prince Edward Island" });
            provinces.Add(new SelectListItem { Text = "Quebec", Value = "Quebec" });
            provinces.Add(new SelectListItem { Text = "Saskatchewan", Value = "Saskatchewan" });

            ViewBag.Province = provinces;

            return View("HostingRequestForm", viewModel);
        }

        [HttpPost]
        public ActionResult SubmitRequest(HostRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("HostingRequestForm", model);
            }

            var selectedAmenities = model.Amenities.Where(m => m.Checked == true).ToList();
            var homeAmenities = new List<SelectedAmenity>();
            foreach (var amenity in selectedAmenities)
            {
                homeAmenities.Add(new SelectedAmenity
                {
                    Name = amenity.Name
                });
            }
            model.Home.Amenities = homeAmenities;

            _context.Homes.Add(model.Home);

            // Create new host request for the new home
            HostRequest request = new HostRequest();
            request.Home = model.Home;
            request.UserID = User.Identity.GetUserId();
            request.RequestDate = DateTime.Now;
            request.RequestStatus = "Pending";
            _context.HostRequests.Add(request);

            _context.SaveChanges();
            return RedirectToAction("HostingRequests", "User", null);
        }

        [Authorize]
        public ActionResult NewBookingRecord(int ID)

        {
            //WIP
            var bookingRecord = new BookingRecord();
            bookingRecord.HomeID = ID;
            bookingRecord.UserID = User.Identity.GetUserId();
            var viewModel = new BookingViewModel()
            {
                bookingRecord = bookingRecord,
                Home = _context.Homes.Where(m => m.ID == ID).SingleOrDefault()
            };
            
            return View("BookingRecordForm", viewModel);
        }

        [HttpPost]
        public ActionResult BookHouse(BookingViewModel model)
        {
            //WIP
            if (!ModelState.IsValid)
            {
                return View("BookingRecordForm", model);
            }

            _context.BookingRecords.Add(model.bookingRecord);
            _context.SaveChanges();
            return RedirectToAction("Index", "House");
        }
    }
}