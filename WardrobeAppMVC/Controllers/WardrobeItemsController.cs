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
    public class WardrobeItemsController : Controller
    {
        private WardrobeDBEntities3 db = new WardrobeDBEntities3();

        // GET: WardrobeItems
        public ActionResult Index()
        {
            var wardrobeItems = db.WardrobeItems.Include(w => w.Occasion).Include(w => w.Season).Include(w => w.WardrobeType);
            return View(wardrobeItems.ToList());
        }

        // GET: WardrobeItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WardrobeItem wardrobeItem = db.WardrobeItems.Find(id);
            if (wardrobeItem == null)
            {
                return HttpNotFound();
            }
            return View(wardrobeItem);
        }

        // GET: WardrobeItems/Create
        public ActionResult Create()
        {
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Description");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Description");
            ViewBag.TypeID = new SelectList(db.WardrobeTypes, "TypeID", "Description");
            return View();
        }

        // POST: WardrobeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Description,Photo,Color,TypeID,SeasonID,OccasionID")] WardrobeItem wardrobeItem)
        {
            if (ModelState.IsValid)
            {
                db.WardrobeItems.Add(wardrobeItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Description", wardrobeItem.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Description", wardrobeItem.SeasonID);
            ViewBag.TypeID = new SelectList(db.WardrobeTypes, "TypeID", "Description", wardrobeItem.TypeID);
            return View(wardrobeItem);
        }

        // GET: WardrobeItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WardrobeItem wardrobeItem = db.WardrobeItems.Find(id);
            if (wardrobeItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Description", wardrobeItem.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Description", wardrobeItem.SeasonID);
            ViewBag.TypeID = new SelectList(db.WardrobeTypes, "TypeID", "Description", wardrobeItem.TypeID);
            return View(wardrobeItem);
        }

        // POST: WardrobeItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Description,Photo,Color,TypeID,SeasonID,OccasionID")] WardrobeItem wardrobeItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wardrobeItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Description", wardrobeItem.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Description", wardrobeItem.SeasonID);
            ViewBag.TypeID = new SelectList(db.WardrobeTypes, "TypeID", "Description", wardrobeItem.TypeID);
            return View(wardrobeItem);
        }

        // GET: WardrobeItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WardrobeItem wardrobeItem = db.WardrobeItems.Find(id);
            if (wardrobeItem == null)
            {
                return HttpNotFound();
            }
            return View(wardrobeItem);
        }

        // POST: WardrobeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WardrobeItem wardrobeItem = db.WardrobeItems.Find(id);
            db.WardrobeItems.Remove(wardrobeItem);
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
