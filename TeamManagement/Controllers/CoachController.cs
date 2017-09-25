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
                    IsNotInjured(player);
                    context.SaveChanges();
                    break;
                case false:
                    player.IsInjured = true;
                    IsInjured(player);
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
            Accepted(applicant);
            RemoveApplication(applicantId);
            context.SaveChanges();
            

            return RedirectToAction("Applications", "Coach");
        }

        [HttpGet]
        public ActionResult DenyApplicant(string applicantId)
        {
            var id = int.Parse(context.Applicaitons.Where(x => x.AspNetUsersId == applicantId).Select(x=>x.Id).ToString());
            var user = context.Users.Where(x => x.Id == id.ToString()).First();


            var applicant = from ids in context.Applicaitons
                            where ids.Id == id
                            select ids;

            foreach(var ids in applicant)
            {
                context.Applicaitons.Remove(ids);
            }
            Denied(user);
            context.SaveChanges();

            return RedirectToAction("Applications", "Coach");
        }

        public void RemoveApplication(string applicantId)
        {
            ApplicationModels applicant = context.Applicaitons.Where(x => x.AspNetUsersId == applicantId).First();

            context.Applicaitons.Remove(applicant);
            context.SaveChanges();
        }

        [HttpGet]
        public ActionResult RemovePlayer(string playerId)
        {
            var player = context.Users.Where(x => x.Id == playerId).First();

            player.Role = "Subscriber";
            context.SaveChanges();
            RemoveAlert(player);

            return RedirectToAction("Manage", "Coach");
        }

        public void RemoveAlert(ApplicationUser player)
        {
            AlertModels alert = new AlertModels();
            alert.AlertMessage = "This is an automated message. You have been removed from the team.";
            alert.AspNetUsersId = player.Id;
            alert.AspNetSenderName = "Team Server";
            alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
            context.Alerts.Add(alert);
            context.SaveChanges();            
        }

        public void Accepted(ApplicationUser player)
        {
            AlertModels alert = new AlertModels();
            alert.AlertMessage = "This is an automated message. Your application has been accept. Welcome to the team!";
            alert.AspNetUsersId = player.Id;
            alert.AspNetSenderName = "Team Server";
            alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
            context.Alerts.Add(alert);
            context.SaveChanges();
        }

        public void Denied(ApplicationUser player)
        {
            AlertModels alert = new AlertModels();
            alert.AlertMessage = "This is an automated message. Your application was denied. If you wish to apply for a different position please return to your profile to begin a new application.";
            alert.AspNetUsersId = player.Id;
            alert.AspNetSenderName = "Team Server";
            alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
            context.Alerts.Add(alert);
            context.SaveChanges();
        }

        public void IsInjured(ApplicationUser player)
        {
            List<TrackingModels> userIds = context.Trackings.Where(x => x.PlayerId == player.Id).ToList();
            var listOfUsers = GetUserList(userIds);
            if (listOfUsers.Count == 0)
            {
                //No users are tracking.
            }
            else
            {
                foreach (var user in listOfUsers)
                {
                    AlertModels alert = new AlertModels();
                    alert.AlertMessage = $"This is an automated message. {player.FirstName} {player.LastName} is now injured.";
                    alert.AspNetUsersId = user.Id.ToString();
                    alert.AspNetSenderName = "Team Server";
                    alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
                    context.Alerts.Add(alert);
                    context.SaveChanges();
                }
            }
        }

        public void IsNotInjured(ApplicationUser player)
        {
            List<TrackingModels> userIds = context.Trackings.Where(x => x.PlayerId == player.Id).ToList();
            var listOfUsers = GetUserList(userIds);
            if (listOfUsers.Count == 0)
            {
                //No users are tracking.
            }
            else
            {
                foreach (var user in listOfUsers)
                {
                    AlertModels alert = new AlertModels();
                    alert.AlertMessage = $"This is an automated message. {player.FirstName} {player.LastName} is not injured anymore.";
                    alert.AspNetUsersId = user.Id.ToString();
                    alert.AspNetSenderName = "Team Server";
                    alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
                    context.Alerts.Add(alert);
                    context.SaveChanges();
                }
            }
        }

        public List<ApplicationUser> GetUserList(List<TrackingModels> userIds)
        {
            List<ApplicationUser> listOfUsers = new List<ApplicationUser>();
            List<ApplicationUser> users = context.Users.Where(x => x.Role == "Subscriber").ToList();
            
            if (userIds.Count == 0)
            {
                //No users.
            }
            else
            {
                for(var i = 0; i < users.Count; i++)
                {
                    ApplicationUser user = new ApplicationUser();
                    if(userIds.Select(x=>x.AspNetUsersId).Contains(users[i].Id))
                    {
                        user = users[i];
                        listOfUsers.Add(user);
                    }
                }
            }
            return listOfUsers;
        } 
    }
}