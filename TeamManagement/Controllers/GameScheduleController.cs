using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class GameScheduleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameSchedule
        public ActionResult Index()
        {
            return View(db.GameSchedules.ToList());
        }

        // GET: GameSchedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameScheduleModels gameScheduleModels = db.GameSchedules.Find(id);
            if (gameScheduleModels == null)
            {
                return HttpNotFound();
            }
            return View(gameScheduleModels);
        }

        // GET: GameSchedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameSchedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameDate,GameTime,Opponent,LocationName,Address,City,State,Zip")] GameScheduleModels gameScheduleModels)
        {
            if (ModelState.IsValid)
            {
                db.GameSchedules.Add(gameScheduleModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameScheduleModels);
        }

        // GET: GameSchedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameScheduleModels gameScheduleModels = db.GameSchedules.Find(id);
            if (gameScheduleModels == null)
            {
                return HttpNotFound();
            }
            return View(gameScheduleModels);
        }

        // POST: GameSchedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameDate,GameTime,Opponent,LocationName,Address,City,State,Zip")] GameScheduleModels gameScheduleModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameScheduleModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameScheduleModels);
        }

        // GET: GameSchedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameScheduleModels gameScheduleModels = db.GameSchedules.Find(id);
            if (gameScheduleModels == null)
            {
                return HttpNotFound();
            }
            return View(gameScheduleModels);
        }

        // POST: GameSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameScheduleModels gameScheduleModels = db.GameSchedules.Find(id);
            db.GameSchedules.Remove(gameScheduleModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
