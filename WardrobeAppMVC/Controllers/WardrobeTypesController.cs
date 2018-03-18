using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeAppMVC.Models;

namespace WardrobeAppMVC.Controllers
{
    public class WardrobeTypesController : Controller
    {
        private WardrobeDBEntities3 db = new WardrobeDBEntities3();

        // GET: WardrobeTypes
        public ActionResult Index()
        {
            return View(db.WardrobeTypes.ToList());
        }

        // GET: WardrobeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WardrobeType wardrobeType = db.WardrobeTypes.Find(id);
            if (wardrobeType == null)
            {
                return HttpNotFound();
            }
            return View(wardrobeType);
        }

        // GET: WardrobeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WardrobeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeID,Description")] WardrobeType wardrobeType)
        {
            if (ModelState.IsValid)
            {
                db.WardrobeTypes.Add(wardrobeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wardrobeType);
        }

        // GET: WardrobeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WardrobeType wardrobeType = db.WardrobeTypes.Find(id);
            if (wardrobeType == null)
            {
                return HttpNotFound();
            }
            return View(wardrobeType);
        }

        // POST: WardrobeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeID,Description")] WardrobeType wardrobeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wardrobeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wardrobeType);
        }

        // GET: WardrobeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WardrobeType wardrobeType = db.WardrobeTypes.Find(id);
            if (wardrobeType == null)
            {
                return HttpNotFound();
            }
            return View(wardrobeType);
        }

        // POST: WardrobeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WardrobeType wardrobeType = db.WardrobeTypes.Find(id);
            db.WardrobeTypes.Remove(wardrobeType);
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
