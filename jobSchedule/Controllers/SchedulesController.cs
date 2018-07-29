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
    public class SchedulesController : Controller
    {
        private jobScheduleContext db = new jobScheduleContext();

        // GET: Schedules
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.beach).Include(f =>f.lifeguard).Include(x=>x.city);
            return View(schedules.ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            //ViewBag.beachID = new SelectList(db.Beaches, "beachID", "beachName");
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            ViewBag.lifeguardID = new SelectList(db.Lifeguards, "lifeguardID", "Lifeguard_Name");
            return View();
        }


        public ActionResult Citycal(int city_id)
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<Beach> beachy = db.Beaches.Where(x => x.city_id == city_id).ToList();
            return Json(beachy, JsonRequestBehavior.AllowGet);     
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scheduleID,lifeguardID,dutyDate,timeStart,timeEnd,city_id,beachID,city_name")] Schedule schedule)
        {
            var lg = db.Lifeguards.Find(schedule.lifeguardID);

            if (ModelState.IsValid)
            {
                if (lg.city_id == schedule.city_id)
                {

                    db.Schedules.Add(schedule);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    ViewBag.tay = "The selected lifeguard does not stay in the same city";
                }
            }

            ViewBag.lifeguardID = new SelectList(db.Lifeguards, "lifeguardID", "Lifeguard_Name", schedule.lifeguardID);
            ViewBag.beachID = new SelectList(db.Beaches, "beachID", "beachName", schedule.beachID);
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", schedule.city_id);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }

            ViewBag.lifeguardID = new SelectList(db.Lifeguards, "lifeguardID", "Lifeguard_Name", schedule.lifeguardID);
            ViewBag.beachID = new SelectList(db.Beaches, "beachID", "beachName", schedule.beachID);
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", schedule.city_id);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scheduleID,lifeguardID,dutyDate,timeStart,timeEnd,city_id,beachID,city_name")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lifeguardID = new SelectList(db.Lifeguards, "lifeguardID", "Lifeguard_Name", schedule.lifeguardID);
            ViewBag.beachID = new SelectList(db.Beaches, "beachID", "beachName", schedule.beachID);
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", schedule.city_id);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
