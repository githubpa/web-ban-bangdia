using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class QTLienHeController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTLienHe/

        public ActionResult Index()
        {
            var lienhes = db.LienHes.Include(l => l.TaiKhoan).Include(l => l.YeuCau);
            return View(lienhes.ToList());
        }

        //
        // GET: /QTLienHe/Details/5

        public ActionResult Details(int id = 0)
        {
            LienHe lienhe = db.LienHes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

        //
        // GET: /QTLienHe/Create

        public ActionResult Create()
        {
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK");
            ViewBag.MaYC = new SelectList(db.YeuCaus, "MaYC", "TenYeuCau");
            return View();
        }

        //
        // POST: /QTLienHe/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LienHe lienhe)
        {
            if (ModelState.IsValid)
            {
                db.LienHes.Add(lienhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", lienhe.MaTK);
            ViewBag.MaYC = new SelectList(db.YeuCaus, "MaYC", "TenYeuCau", lienhe.MaYC);
            return View(lienhe);
        }

        //
        // GET: /QTLienHe/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LienHe lienhe = db.LienHes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", lienhe.MaTK);
            ViewBag.MaYC = new SelectList(db.YeuCaus, "MaYC", "TenYeuCau", lienhe.MaYC);
            return View(lienhe);
        }

        //
        // POST: /QTLienHe/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LienHe lienhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lienhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", lienhe.MaTK);
            ViewBag.MaYC = new SelectList(db.YeuCaus, "MaYC", "TenYeuCau", lienhe.MaYC);
            return View(lienhe);
        }

        //
        // GET: /QTLienHe/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LienHe lienhe = db.LienHes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

        //
        // POST: /QTLienHe/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LienHe lienhe = db.LienHes.Find(id);
            db.LienHes.Remove(lienhe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}