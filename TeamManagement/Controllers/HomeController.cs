using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TeamManagement.Models;
using TeamManagement.ViewModels;

namespace TeamManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var _context = new ApplicationDbContext();
            var email = User.Identity.GetUserName();
            var _user = _context.Users.Where(u => u.Email == email).FirstOrDefault();

            var layoutViewModel = new LayoutViewModels
            {
                CurrentUser = _user,
                GameSchedule = _context.GameSchedules.Select(g => g).ToList()
            };

            return View(layoutViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}