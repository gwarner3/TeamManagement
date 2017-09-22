using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;
using TeamManagement.ViewModels;

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

        [HttpGet]
        public ActionResult Manage()
        {
            var user = User.Identity.GetUserName();
            var coach = context.Users.Where(x => x.UserName == user && x.Role == "Coach").First();
            var team = context.Users.Where(x => x.Role == "Player").ToList();
            coach.Players = team;

            return View(coach);
        }

        [HttpGet]
        public ActionResult Attendance()
        {
            //var gameDates = context.GameSchedules.ToList();

            var attendanceViewModel = new AttendanceViewModel
            {
                Players = context.Users.Where(x => x.Role == "Player").ToList(),
            //    GameScheduleModels = gameDates,
            };

            var players = context.Users.Where(x => x.Role == "Player").ToList();

            return View(attendanceViewModel);
        }

        [HttpPost]
        public ActionResult Attendance(AttendanceViewModel vm)
        {
            return RedirectToAction("UpdateAttendance", "Coach");
        }

        public ActionResult UpdateAttendance(AttendanceViewModel vm)
        {
            return RedirectToAction("Attendance", "Coach");
        }

        [HttpGet]
        public ActionResult ChangeStatus(string playerId)
        {
            var player = context.Users.Where(x => x.Id == playerId).First();
            
            switch(player.IsInjured)
            {
                case true:
                    player.IsInjured = false;
                    context.SaveChanges();
                    break;
                case false:
                    player.IsInjured = true;
                    context.SaveChanges();
                    break;
            }
            
            return RedirectToAction("Manage", "Coach");
        }

        [HttpGet]
        public ActionResult Applications()
        {
            var applicants = context.Applicaitons.Select(x => x).ToList();
            List<ApplicationUser> applicantList = new List<ApplicationUser>();
            foreach (var id in applicants)
            {
                applicantList.Add(context.Users.Where(x => x.Id == id.AspNetUsersId).First());
            }
            var coachUserName = User.Identity.GetUserName();
            var coach = context.Users.Where(x => x.UserName == coachUserName).First();
            coach.Players = applicantList;

            return View(coach);
        }

        [HttpGet]
        public ActionResult AcceptApplicant(string applicantId)
        {
            var applicant = context.Users.Where(x => x.Id == applicantId).First();
            applicant.Role = "Player";
            context.SaveChanges();

            return RedirectToAction("Applications", "Coach");
        }

        [HttpGet]
        public ActionResult DenyApplicant(string applicantId)
        {
            var id = int.Parse(context.Applicaitons.Where(x => x.AspNetUsersId == applicantId).Select(x=>x.Id).ToString());

            var applicant = from ids in context.Applicaitons
                            where ids.Id == id
                            select ids;

            foreach(var ids in applicant)
            {
                context.Applicaitons.Remove(ids);
            }

            return RedirectToAction("Applications", "Coach");
        }
    }
}