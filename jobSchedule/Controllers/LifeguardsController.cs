using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jobSchedule.Models;

namespace jobSchedule.Controllers
{
    public class LifeguardsController : Controller
    {
        private jobScheduleContext db = new jobScheduleContext();

        // GET: Lifeguards
        public ActionResult Index()
        {
            var lifeguards = db.Lifeguards.Include(l => l.city);
            return View(lifeguards.ToList());
        }

        // GET: Lifeguards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifeguard lifeguard = db.Lifeguards.Find(id);
            if (lifeguard == null)
            {
                return HttpNotFound();
            }
            return View(lifeguard);
        }

        // GET: Lifeguards/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            return View();
        }

        // POST: Lifeguards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lifeguardID,Lifeguard_Name,DOB,gender,city_id")] Lifeguard lifeguard)
        {
            if (ModelState.IsValid)
            {
                db.Lifeguards.Add(lifeguard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", lifeguard.city_id);
            return View(lifeguard);
        }

        // GET: Lifeguards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifeguard lifeguard = db.Lifeguards.Find(id);
            if (lifeguard == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", lifeguard.city_id);
            return View(lifeguard);
        }

        // POST: Lifeguards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lifeguardID,Lifeguard_Name,DOB,gender,city_id")] Lifeguard lifeguard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lifeguard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", lifeguard.city_id);
            return View(lifeguard);
        }

        // GET: Lifeguards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifeguard lifeguard = db.Lifeguards.Find(id);
            if (lifeguard == null)
            {
                return HttpNotFound();
            }
            return View(lifeguard);
        }

        // POST: Lifeguards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lifeguard lifeguard = db.Lifeguards.Find(id);
            db.Lifeguards.Remove(lifeguard);
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
