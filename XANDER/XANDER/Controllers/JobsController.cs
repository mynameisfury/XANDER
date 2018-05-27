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
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ClientJobs()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var client = db.Clients.Where(c => c.UserID == user.Id).FirstOrDefault();
            var jobs = db.Jobs.Where(j => j.ClientID == client.ID);
            return View(jobs.ToList());
        }
        public ActionResult WorkerJobs()
        {
            var jobs = db.Jobs.Include(j => j.Client).Include(j => j.JobType).Include(j => j.Worker).Where(j => j.Accepted == false);
            return View(jobs.ToList());
        
        }

        public ActionResult InProgress()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var worker = db.Workers.Where(c => c.UserID == user.Id).FirstOrDefault();
            var jobs = db.Jobs.Where(j => j.WorkerID == worker.ID);
            return View(jobs.ToList());

        }

        public ActionResult AcceptJob(int? id)
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var worker = db.Workers.Where(c => c.UserID == user.Id).FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            job.WorkerID = worker.ID;
            job.Worker = worker;
            job.Accepted = true;
            db.SaveChanges();
            return View(job);
        }

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Client).Include(j => j.JobType).Include(j => j.Worker);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        public ActionResult WorkerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var client = db.Clients.Where(c => c.UserID == user.Id).FirstOrDefault();

            ViewBag.ClientID = client.ID;
            //new SelectList(db.Clients.Where(c => c.UserID == user.Id), "ID", "FirstName");
            ViewBag.JobTypeID = new SelectList(db.JobTypes, "ID", "Type");
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FirstName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClientID,WorkerID,JobName,JobTypeID,JobDescription,JobPayout,DueDate")] Job job)
        {
            if (ModelState.IsValid)
            {
                string userID = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
                var client = db.Clients.Where(c => c.UserID == user.Id).FirstOrDefault();
                job.ClientID = client.ID;
                ViewBag.ClientID = client.ID;
                //new SelectList(db.Clients.Where(c => c.UserID == user.Id), "ID", "FirstName", job.ClientID);
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobTypeID = new SelectList(db.JobTypes, "ID", "Type", job.JobTypeID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FirstName", job.WorkerID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", job.ClientID);
            ViewBag.JobTypeID = new SelectList(db.JobTypes, "ID", "Type", job.JobTypeID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FirstName", job.WorkerID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientID,WorkerID,JobName,JobTypeID,JobDescription,JobPayout,DueDate,Completed")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", job.ClientID);
            ViewBag.JobTypeID = new SelectList(db.JobTypes, "ID", "Type", job.JobTypeID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "FirstName", job.WorkerID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
