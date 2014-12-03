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
    public class QTYeuCauController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTYeuCau/

        public ActionResult Index()
        {
            return View(db.YeuCaus.ToList());
        }

        //
        // GET: /QTYeuCau/Details/5

        public ActionResult Details(int id = 0)
        {
            YeuCau yeucau = db.YeuCaus.Find(id);
            if (yeucau == null)
            {
                return HttpNotFound();
            }
            return View(yeucau);
        }

        //
        // GET: /QTYeuCau/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QTYeuCau/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(YeuCau yeucau)
        {
            if (ModelState.IsValid)
            {
                db.YeuCaus.Add(yeucau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yeucau);
        }

        //
        // GET: /QTYeuCau/Edit/5

        public ActionResult Edit(int id = 0)
        {
            YeuCau yeucau = db.YeuCaus.Find(id);
            if (yeucau == null)
            {
                return HttpNotFound();
            }
            return View(yeucau);
        }

        //
        // POST: /QTYeuCau/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(YeuCau yeucau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yeucau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yeucau);
        }

        //
        // GET: /QTYeuCau/Delete/5

        public ActionResult Delete(int id = 0)
        {
            YeuCau yeucau = db.YeuCaus.Find(id);
            if (yeucau == null)
            {
                return HttpNotFound();
            }
            return View(yeucau);
        }

        //
        // POST: /QTYeuCau/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YeuCau yeucau = db.YeuCaus.Find(id);
            db.YeuCaus.Remove(yeucau);
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