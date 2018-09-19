using HouseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseProject.ViewModels
{
    public class TransactionsViewModel
    {
        public IEnumerable<BookingRecord> BookingRecords { get; set; }
        public IEnumerable<Home> Homes { get; set; }
    }
}