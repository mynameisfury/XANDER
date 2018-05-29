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
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index()
        {
            var messages = db.Messages.Include(m => m.Client).Include(m => m.Worker);
            return View(messages.ToList());
        }
        public ActionResult ClientMessages()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var client = db.Clients.Where(c => c.UserID == user.Id).FirstOrDefault();
            var messages = db.Messages.Where(m => m.ClientID == client.ID);
            return View(messages.ToList());
        }
        public ActionResult WorkerMessages()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var worker = db.Workers.Where(c => c.UserID == user.Id).FirstOrDefault();
            var messages = db.Messages.Where(m => m.WorkerID == worker.ID);
            return View(messages.ToList());
        }
        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        public ActionResult ClientCreate()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var client = db.Clients.Where(c => c.UserID == user.Id).FirstOrDefault();
            ViewBag.ClientID = client.ID;
            ViewBag.TimeStamp = DateTime.Now;
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username");
            return View();
        }
        public ActionResult WorkerCreate()
        {
            string userID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            var worker = db.Workers.Where(c => c.UserID == user.Id).FirstOrDefault();
            ViewBag.TimeStamp = DateTime.Now;
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Username");
            ViewBag.WorkerID = worker.ID;
            return View();

        }
        // GET: Messages/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName");
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MessageBody,TimeStamp,ClientID,WorkerID")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", message.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username", message.WorkerID);
            return View(message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCreate([Bind(Include = "ID,MessageBody,TimeStamp,ClientID,WorkerID")] Message message)
        {
            if (ModelState.IsValid)
            {
                string userID = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
                var client = db.Clients.Where(c => c.UserID == user.Id).FirstOrDefault();
                message.ClientID = client.ID;
                message.TimeStamp = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("ClientMessages");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", message.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username", message.WorkerID);
            return View(message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkerCreate([Bind(Include = "ID,MessageBody,TimeStamp,ClientID,WorkerID")] Message message)
        {
            if (ModelState.IsValid)
            {
                string userID = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
                var worker = db.Workers.Where(w => w.UserID == user.Id).FirstOrDefault();
                message.WorkerID = worker.ID;
                message.TimeStamp = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("WorkerMessages");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", message.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username", message.WorkerID);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", message.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username", message.WorkerID);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MessageBody,TimeStamp,ClientID,WorkerID")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FirstName", message.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "Username", message.WorkerID);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            if (User.IsInRole("Client"))
            {
                return RedirectToAction("ClientMessages");
            }
            else if (User.IsInRole("Worker"))
            {
                return RedirectToAction("WorkerMessages");
            }

            else return RedirectToAction("Index");
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
