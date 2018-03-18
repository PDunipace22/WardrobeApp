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
    public class OutfitsController : Controller
    {
        private WardrobeDBEntities3 db = new WardrobeDBEntities3();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.WardrobeItem).Include(o => o.WardrobeItem1).Include(o => o.WardrobeItem2).Include(o => o.WardrobeItem3);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Accessory"), "ItemID", "Description");
            ViewBag.BottomID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Bottom"), "ItemID", "Description");
            ViewBag.ShoeID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Shoe"), "ItemID", "Description");
            ViewBag.TopID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Top"), "ItemID", "Description");
            return View();
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,Description,TopID,BottomID,ShoeID,AccessoryID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Accessory"), "ItemID", "Description", outfit.AccessoryID);
            ViewBag.BottomID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Bottom"), "ItemID", "Description", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Shoe"), "ItemID", "Description", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Top"), "ItemID", "Description", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Accessory"), "ItemID", "Description", outfit.AccessoryID);
            ViewBag.BottomID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Bottom"), "ItemID", "Description", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Shoe"), "ItemID", "Description", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Top"), "ItemID", "Description", outfit.TopID);
            return View(outfit);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,Description,TopID,BottomID,ShoeID,AccessoryID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Accessory"), "ItemID", "Description", outfit.AccessoryID);
            ViewBag.BottomID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Bottom"), "ItemID", "Description", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Shoe"), "ItemID", "Description", outfit.ShoeID);
            ViewBag.TopID = new SelectList(db.WardrobeItems.Where(p => p.WardrobeType.Description == "Top"), "ItemID", "Description", outfit.TopID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
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
