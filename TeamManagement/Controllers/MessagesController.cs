using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class MessagesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Messages
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AlertModels message)
        {
            var userName = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == userName).First();
            var senderName = user.FirstName + " " + user.LastName;
            var team = context.Users.Where(x => x.Role == "Coach" || x.Role == "Player").ToList();
            DateTime time = DateTime.Today;
            var sentDate = time;

            foreach(var member in team)
            {
                AlertModels messages = new AlertModels();
                messages.AspNetUsersId = member.Id;
                messages.AspNetSenderName = senderName;
                messages.AlertMessage = message.AlertMessage;
                messages.DateSent = time.ToString("MM-dd-yyyy");
                context.Alerts.Add(messages);
                context.SaveChanges();
            }

            return RedirectToAction("SentMessage", "Messages");
        }

        [HttpGet]
        public ActionResult SentMessage()
        {
            return View();
        }
    }
}