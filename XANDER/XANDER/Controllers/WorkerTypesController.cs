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
    public class WorkerTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkerTypes
        public ActionResult Index()
        {
            return View(db.WorkerTypes.ToList());
        }

        // GET: WorkerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerType workerType = db.WorkerTypes.Find(id);
            if (workerType == null)
            {
                return HttpNotFound();
            }
            return View(workerType);
        }

        // GET: WorkerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] WorkerType workerType)
        {
            if (ModelState.IsValid)
            {
                db.WorkerTypes.Add(workerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workerType);
        }

        // GET: WorkerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerType workerType = db.WorkerTypes.Find(id);
            if (workerType == null)
            {
                return HttpNotFound();
            }
            return View(workerType);
        }

        // POST: WorkerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] WorkerType workerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workerType);
        }

        // GET: WorkerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerType workerType = db.WorkerTypes.Find(id);
            if (workerType == null)
            {
                return HttpNotFound();
            }
            return View(workerType);
        }

        // POST: WorkerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerType workerType = db.WorkerTypes.Find(id);
            db.WorkerTypes.Remove(workerType);
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
