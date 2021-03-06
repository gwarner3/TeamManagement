﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using TeamManagement.Models;
using TeamManagement.ViewModels;

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
        public async System.Threading.Tasks.Task<ActionResult> Details(int? id)
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

            GameScheduleModelWithLatLong gs = new GameScheduleModelWithLatLong
            {
              GameScheduleWithLatLong = gameScheduleModels
            };

            var address = gameScheduleModels.Address.Split(' ');
            var addresspercent = string.Join("%", address);
            var city = gameScheduleModels.City.ToString();
            var state = gameScheduleModels.State.ToString();
            var zip = gameScheduleModels.Zip.ToString();
            var mapAddres = addresspercent + "%" + city + "%" + state + "%" + zip;
            var client1 = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + mapAddres + "&key=AIzaSyCD9K9065uQrMDhHXA7CuOVkfGS6jwV2x0");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "bb2cc651-09d7-2ab4-7fcf-3dd1b6e34291");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response1 = client1.Execute(request);

            string xyz = response1.Content.ToString();
            int lonStart1 = xyz.IndexOf("\"lat\" : ") + 8;
            int lonEnd1 = xyz.IndexOf(",\n ", lonStart1);
            string lon1 = xyz.Substring(lonStart1, lonEnd1 - lonStart1);


            //string apiUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=1600%20Amphitheatre%20Parkway%2C%20Mountain%20View%2C%20CA&key=AIzaSyCD9K9065uQrMDhHXA7CuOVkfGS6jwV2x0";
            string apiUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + mapAddres + "&key=AIzaSyCD9K9065uQrMDhHXA7CuOVkfGS6jwV2x0";
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue());
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                string encodedStringResponse = await response.Content.ReadAsStringAsync();

                int latStart = encodedStringResponse.IndexOf("\"lat\" : ") + 8;
                int latEnd = encodedStringResponse.IndexOf(",\n ", latStart);
                string lat = encodedStringResponse.Substring(latStart, latEnd - latStart);
                gs.Lat = lat;


                int lonStart = encodedStringResponse.IndexOf("\"lng\" : ") + 8;
                int lonEnd = encodedStringResponse.IndexOf("\n ", lonStart);
                string lon = encodedStringResponse.Substring(lonStart, lonEnd - lonStart);
                gs.Long = lon;
            };

            //Weather api tests
            //var weatherClient = new RestClient("http://api.openweathermap.org/data/2.5/forecast?zip=53218&appid=0ab248ac8b8a306823b9e7881aaddad4");
            //var weatherRrequest = new RestRequest(Method.GET);
            //request.AddHeader("postman-token", "17cbd1ce-2f19-7346-9524-6d04c9c1d13e");
            //request.AddHeader("cache-control", "no-cache");
            //IRestResponse weatherResponse = weatherClient.Execute(weatherRrequest);

            
            

            return View(gs);
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
                AlertNewEvent(gameScheduleModels);
                
                return RedirectToAction("Index");
            }

            return View(gameScheduleModels);
        }

        public void AlertNewEvent(GameScheduleModels model)
        {
            AlertModels alert = new AlertModels();
            var users = db.Users.Select(x => x).ToList();

            foreach(var user in users)
            {
                alert.AlertMessage = $"There is an event {model.EventName} on {model.GameDate}.";
                alert.GameDate = model.GameDate;
                alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
                alert.Received = false;
                alert.AspNetUsersId = user.Id;
                db.Alerts.Add(alert);
                db.SaveChanges();
            }
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
            AlertDelete(gameScheduleModels);

            return RedirectToAction("Index");
        }

        public void AlertDelete(GameScheduleModels model)
        {
            AlertModels alert = new AlertModels();
            var users = db.Users.Select(x => x).ToList();

            if (model.GameDate < DateTime.Today)
            {
                //ignore delete.
            }
            else
            {
                foreach (var user in users)
                {
                    alert.AlertMessage = $"The event {model.EventName} on {model.GameDate} has been deleted.";
                    alert.GameDate = model.GameDate;
                    alert.DateSent = DateTime.Today.ToString("MM-dd-yyyy");
                    alert.Received = false;
                    alert.AspNetUsersId = user.Id;
                    db.Alerts.Add(alert);
                    db.SaveChanges();
                }
            }
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
