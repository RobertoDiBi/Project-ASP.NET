using HouseProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HouseProject.ViewModels;

namespace HouseProject.Controllers
{
    public class UserController : Controller
    {
        public ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            return View(User);
        }

        [Authorize]
        public ActionResult Transactions()
        {
            var userID = User.Identity.GetUserId();
            var viewModel = new TransactionsViewModel
            {
                BookingRecords = _context.BookingRecords.Include(m => m.Home).
                Where(m => m.UserID == userID),
                Homes = _context.Homes.ToList()
            };
            
            return View(viewModel);
        }

        [Authorize]
        public ActionResult HostingRequests()
        {
            var userID = User.Identity.GetUserId();
            
            var records = _context.HostRequests.Include(m => m.Home).
                Include(m => m.Home.HomeType).
                Include(m => m.Home.Amenities).Where(m => m.UserID == userID);
            return View(records.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageRequests()
        {
            var viewModel = new ManageRequestsViewModel
            {
                HostRequests = _context.HostRequests.Include(m => m.Home.Amenities).
                Where(m => m.RequestStatus == "Pending"),
                Homes = _context.Homes.ToList(),
                HomeTypes = _context.HomeTypes.ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ApproveRequest(int id)
        {
            var request = _context.HostRequests.Include(m => m.Home).SingleOrDefault(m => m.ID == id);
            request.RequestStatus = "Approved";
            request.Home.Approved = true;
            _context.SaveChanges();
            return RedirectToAction("ManageRequests");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeclineRequest(int id)
        {
            var request = _context.HostRequests.Include(m => m.Home).SingleOrDefault(m => m.ID == id);
            request.RequestStatus = "Declined";
            request.Home.Approved = false;
            _context.SaveChanges();
            return RedirectToAction("ManageRequests");
        }
    }
}