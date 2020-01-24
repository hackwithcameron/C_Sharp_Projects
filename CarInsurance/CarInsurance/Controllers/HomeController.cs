using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuoteInfo(string firstName, string lastName, string emailAddress, DateTime dob, string carYear, string carMake, string carModel, string dui,
                                    int speedTickets, string coverage)
        {
            decimal total = 50;
            int age = FindAge(dob);

            if (age < 18) total += 100;
            else if (age < 25) total += 25;
            else if (age > 100) total += 25;

            int convertedCarYear = Convert.ToInt32(carYear);
            if (convertedCarYear < 2000) total += 25;
            if (convertedCarYear > 2015) total += 25;

            string lowerCarMake = carMake.ToLower();
            if (lowerCarMake == "porsche") total += 25;
            if (lowerCarMake == "porsche" && carModel == "911") total += 25;

            for (int i = 0; i < speedTickets; i++) total += 10;

            if (dui == "Yes")
            {
                var totalInt = Convert.ToInt32(total);
                var answer = totalInt * .25;
                total += Convert.ToDecimal(answer);
            }

            if (coverage == "Full Coverage")
            {
                var totalInt = Convert.ToInt32(total);
                var answer = totalInt * .5;
                total += Convert.ToDecimal(answer);
            }


            // Adds entry to db

            using (QuotesEntities db = new QuotesEntities())
            {
                var user = new User
                {
                    First_Name = firstName,
                    Last_Name = lastName,
                    Email_Address = emailAddress,
                    DOB = dob,
                    DUI = dui,
                    Speeding_Tickets = speedTickets,
                    Coverage = coverage,
                    Quote = total
                };

                db.Users.Add(user);
                db.SaveChanges();
                var car = new Car
                {
                    Car_Make = carMake,
                    Car_Model = carModel,
                    Car_Year = carYear
                };
                db.Cars.Add(car);
                db.SaveChanges();
                return View(user);
            }
        }


        public int FindAge(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year - 1;

            return Years;
        }

    }
}