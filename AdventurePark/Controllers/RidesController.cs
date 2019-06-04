using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventurePark.Models;

namespace AdventurePark.Controllers
{
    public class RidesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rides
        public ActionResult Index()
        {
            return View(db.Rides.ToList());
        }


        //Administraatori lehekülg
        [Authorize]
        public ActionResult IndexAdmin()
        {
            return View(db.Rides.ToList());
        }

        //Valitud sõidu alustamine
        public ActionResult RideRollerCoaster()
        {
           return View();
        }


        // GET: Rides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rides rides = db.Rides.Find(id);
            if (rides == null)
            {
                return HttpNotFound();
            }
            return View(rides);
        }

        // GET: Rides/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideID,RideName,RideDifficultyLevel,RideAgeRequirement")] Rides rides)
        {
            if (ModelState.IsValid)
            {
                db.Rides.Add(rides);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rides);
        }

        // GET: Rides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rides rides = db.Rides.Find(id);
            if (rides == null)
            {
                return HttpNotFound();
            }
            return View(rides);
        }

        // POST: Rides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RideID,RideName,RideDifficultyLevel,RideAgeRequirement")] Rides rides)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rides).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rides);
        }

        // GET: Rides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rides rides = db.Rides.Find(id);
            if (rides == null)
            {
                return HttpNotFound();
            }
            return View(rides);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rides rides = db.Rides.Find(id);
            db.Rides.Remove(rides);
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
