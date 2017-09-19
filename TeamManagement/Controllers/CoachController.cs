using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class CoachController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        
        // GET: Coach
        [HttpGet]
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();
            var coach = context.Users.Where(x=> x.UserName == user && x.Role == "Coach").First();

            return View(coach);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var user = User.Identity.GetUserName();
            var coach = context.Users.Where(x => x.UserName == user && x.Role == "Coach").First();

            return View(coach);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser coach)
        {
            var user = User.Identity.GetUserName();
            var coachInfo = context.Users.Where(x => x.UserName == user && x.Role == "Coach").First();

            coachInfo.FirstName = coach.FirstName;
            coachInfo.LastName = coach.LastName;
            coachInfo.Address = coach.Address;
            coachInfo.Zip = coach.Zip;
            coachInfo.PhoneNumber = coach.Phone;
            coachInfo.Email = coach.Email;
            context.SaveChanges();

            return RedirectToAction("Index", "Coach");
        }
    }
}