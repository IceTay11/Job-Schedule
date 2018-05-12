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
    public class BeachesController : Controller
    {
        private jobScheduleContext db = new jobScheduleContext();

        // GET: Beaches
        public ActionResult Index()
        {
            var beaches = db.Beaches.Include(b => b.city);
            return View(beaches.ToList());
        }

        // GET: Beaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beach beach = db.Beaches.Find(id);
            if (beach == null)
            {
                return HttpNotFound();
            }
            return View(beach);
        }

        // GET: Beaches/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            return View();
        }

        // POST: Beaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "beachID,beachName,city_id")] Beach beach)
        {
            if (ModelState.IsValid)
            {
                db.Beaches.Add(beach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", beach.city_id);
            return View(beach);
        }

        // GET: Beaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beach beach = db.Beaches.Find(id);
            if (beach == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", beach.city_id);
            return View(beach);
        }

        // POST: Beaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "beachID,beachName,city_id")] Beach beach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", beach.city_id);
            return View(beach);
        }

        // GET: Beaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beach beach = db.Beaches.Find(id);
            if (beach == null)
            {
                return HttpNotFound();
            }
            return View(beach);
        }

        // POST: Beaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beach beach = db.Beaches.Find(id);
            db.Beaches.Remove(beach);
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
