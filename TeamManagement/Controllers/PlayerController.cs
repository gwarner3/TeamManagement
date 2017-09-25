using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class PlayerController : Controller
    {
        public ApplicationDbContext context;

        public PlayerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Player
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var player = context.Users.Where(x => x.Id == user).First();
            return View(player);
        }

        [HttpPost]
        public ActionResult Index(ApplicationUser player)
        {
            return View();
        }


        // GET: Player/Details/5
        public ActionResult Application()
        {
            var user = User.Identity.GetUserId();
            var subscriber = context.Users.Where(x => x.Id == user).First();
            return View();
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Edit/5
        [HttpGet]
        public ActionResult Edit()
        {
            var user = User.Identity.GetUserId();
            var player = context.Users.Where(x => x.Id == user).First();

            return View(player);
        }

        // POST: Player/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplicationUser player)
        {
            var userId = User.Identity.GetUserId();
            var playerInfo = context.Users.Where(x => x.Id == userId).First();

            playerInfo.FirstName = player.FirstName;
            playerInfo.LastName = player.LastName;
            playerInfo.PhoneNumber = player.PhoneNumber;
            playerInfo.Address = player.Address;
            playerInfo.City = player.City;
            playerInfo.State = player.State;
            playerInfo.Zip = player.Zip;

            context.SaveChanges();


            return View();
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Schedule()
        {
            var schedule = context.GameSchedules.ToList();

            return View(schedule);
        }

        [HttpGet]
        public ActionResult Team()
        {
            var players = context.Users.Where(x=>x.Role == "Player").ToList();

            return View(players);
        }

    }
}
