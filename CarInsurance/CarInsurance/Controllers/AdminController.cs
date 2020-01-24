using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;
using CarInsurance.ViewModels;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (QuotesEntities db = new QuotesEntities())
            {
                var quotes = db.Users.ToList();
                var quoteVMs = new List<QuoteVM>();
                foreach (var quote in quotes)
                {
                    var quoteVM = new QuoteVM();
                    quoteVM.Id = quote.Id;
                    quoteVM.FirstName = quote.First_Name;
                    quoteVM.LastName = quote.Last_Name;
                    quoteVM.EmailAddress = quote.Email_Address;
                    quoteVM.Quote = quote.Quote.GetValueOrDefault();

                    quoteVMs.Add(quoteVM);
                }
                return View(quoteVMs);
            }
        }
    }
}