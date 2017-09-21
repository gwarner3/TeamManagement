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
            var team = context.Users.Where(x => x.Role == "Coach" || x.Role == "Player").ToList();

            foreach(var member in team)
            {
                AlertModels messages = new AlertModels();
                messages.AspNetUsersId = member.Id;
                messages.AlertMessage = message.AlertMessage;
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