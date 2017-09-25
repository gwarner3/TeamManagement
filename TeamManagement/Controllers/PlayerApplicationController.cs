using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class PlayerApplicationController : Controller
    {

        private ApplicationDbContext context;
        public PlayerApplicationController()
        {
            context = new ApplicationDbContext();
        }
        // GET: PlayerApplication
        public ActionResult Index()
        {
            var position = new List<string>{"Goal Keeper", "Defender", "Mid-Fielder", "Forward"};
            

            var playerApplication = new PlayerRegistration()
            {
                PositionType = new SelectList(position)

            };
            return View(playerApplication);
        }

   

        // GET: PlayerApplication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlayerApplication/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: PlayerApplication/Create
        [HttpPost]
        public ActionResult Create(PlayerRegistration playerRegistration)
        {
            try
            {
                // TODO: Add insert logic here
                //var user = context.Users.Create();
                //user.FirstName = playerRegistration.FirstName;
                //user.LastName = playerRegistration.LastName;
                //user.Address = playerRegistration.Address;
                //user.City = playerRegistration.City;
                //user.State = playerRegistration.State;
                //user.Zip = playerRegistration.Zip;
                //user.PhoneNumber = playerRegistration.PhoneNumber;
                //user.Position = playerRegistration.SelectedPosition;

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerApplication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlayerApplication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerApplication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayerApplication/Delete/5
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
    }
}
