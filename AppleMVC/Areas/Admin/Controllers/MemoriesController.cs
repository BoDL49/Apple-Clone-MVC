using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppleMVC.Models;

namespace AppleMVC.Areas.Admin.Controllers
{
    public class MemoriesController : Controller
    {
        private DBAppleStoreEntities db = new DBAppleStoreEntities();

        // GET: Admin/Memories
        public ActionResult Index()
        {
            return View(db.Memories.ToList());
        }

        // GET: Admin/Memories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memory memory = db.Memories.Find(id);
            if (memory == null)
            {
                return HttpNotFound();
            }
            return View(memory);
        }

        // GET: Admin/Memories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Memories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemoryID,MemoryName")] Memory memory)
        {
            if (ModelState.IsValid)
            {
                db.Memories.Add(memory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memory);
        }

        // GET: Admin/Memories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memory memory = db.Memories.Find(id);
            if (memory == null)
            {
                return HttpNotFound();
            }
            return View(memory);
        }

        // POST: Admin/Memories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemoryID,MemoryName")] Memory memory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memory);
        }

        // GET: Admin/Memories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memory memory = db.Memories.Find(id);
            if (memory == null)
            {
                return HttpNotFound();
            }
            return View(memory);
        }

        // POST: Admin/Memories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Memory memory = db.Memories.Find(id);
            db.Memories.Remove(memory);
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
