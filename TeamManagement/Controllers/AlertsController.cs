using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class AlertsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Alerts
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == userName).First();

            AlertModels alerts = new AlertModels();
            alerts.Alerts = context.Alerts.Where(x => x.AspNetUsersId == user.Id).ToList();
            alerts.AspNetUsers = user;

            return View(alerts);
        }

        [HttpGet]
        public ActionResult Delete(string alertId)
        {
            var message = from messages in context.Alerts
                          where messages.Id.ToString() == alertId
                          select messages;

            foreach(var messages in message)
            {
                context.Alerts.Remove(messages);
                
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Alerts");
        }
    }
}