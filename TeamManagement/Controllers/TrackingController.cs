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
    public class TrackingController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Tracking
        public ActionResult Index()
        {
            TrackingViewModels tracking = new TrackingViewModels();
            var userName = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == userName).First();
            var players = context.Users.Where(x => x.Role == "Player").ToList();
            var trackingList = context.Trackings.Where(x => x.AspNetUsersId == user.Id).ToList();
            var ratingsList = context.Ratings.Select(x => x).ToList();
            tracking.AspNetUser = user;
            tracking.Track = trackingList;
            tracking.Player = players;
            tracking.Rate = ratingsList;


            return View(tracking);
        }

        [HttpGet]
        public ActionResult TrackPlayer(string playerId)
        {
            var userName = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == userName).First();
            TrackingModels tracker = new TrackingModels();
            tracker.AspNetUsersId = user.Id;
            tracker.PlayerId = playerId;
            context.Trackings.Add(tracker);
            context.SaveChanges();

            return RedirectToAction("Index", "Tracking");
        }

        [HttpGet]
        public ActionResult RemoveTracking(string trackerId)
        {
            var removeTracker = from tracker in context.Trackings
                                where tracker.PlayerId == trackerId
                                select tracker;
            foreach(var track in removeTracker)
            {
                context.Trackings.Remove(track);
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Tracking");
        }
    }
}