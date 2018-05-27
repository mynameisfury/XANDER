using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XANDER.Models;

namespace XANDER.Controllers
{
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult WorkerHome()
        {
            return View();
        }
        public ActionResult SearchWorkers()
        {
            var workers = db.Workers.Include(w => w.WorkerType);
            return View(workers.ToList());
        }

        // GET: Workers
        public ActionResult Index()
        {
            var workers = db.Workers.Include(w => w.WorkerType);
            return View(workers.ToList());
        }

        // GET: Workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            ViewBag.WorkerTypeID = new SelectList(db.WorkerTypes, "ID", "Type");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,FirstName,LastName,UserID,ProfileDescription,Rating,WorkerTypeID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                worker.UserID = User.Identity.GetUserId();
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkerTypeID = new SelectList(db.WorkerTypes, "ID", "Type", worker.WorkerTypeID);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkerTypeID = new SelectList(db.WorkerTypes, "ID", "Type", worker.WorkerTypeID);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,FirstName,LastName,UserID,ProfileDescription,Rating,WorkerTypeID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkerTypeID = new SelectList(db.WorkerTypes, "ID", "Type", worker.WorkerTypeID);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Workers.Find(id);
            db.Workers.Remove(worker);
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
