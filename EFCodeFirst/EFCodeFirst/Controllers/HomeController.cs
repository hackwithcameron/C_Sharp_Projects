using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCodeFirst.Models;
using EFCodeFirst.DAL;

namespace EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewAccount(string firstName, string lastName, string email)
        {
            using (WebsiteDB db = new WebsiteDB())
            {
                var newAccount = new NewAccount
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = email
                };

                db.NewAccounts.Add(newAccount);
                //db.SaveChanges();

                var accounts = db.NewAccounts;
                var accountVMs = new List<NewAccount>();
                foreach (var account in accounts)
                {
                    var accountVM = new NewAccount();
                    accountVM.ID = account.ID;
                    accountVM.FirstName = account.FirstName;
                    accountVM.LastName = account.LastName;
                    accountVM.EmailAddress = account.EmailAddress;
                    accountVMs.Add(accountVM);
                }
                return View(accountVMs);
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
