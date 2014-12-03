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
    public class QTDanhMucController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTDanhMuc/

        public ActionResult Index()
        {
            return View(db.DanhMucs.ToList());
        }

        //
        // GET: /QTDanhMuc/Details/5

        public ActionResult Details(int id = 0)
        {
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        //
        // GET: /QTDanhMuc/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QTDanhMuc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucs.Add(danhmuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhmuc);
        }

        //
        // GET: /QTDanhMuc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        //
        // POST: /QTDanhMuc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhmuc);
        }

        //
        // GET: /QTDanhMuc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        //
        // POST: /QTDanhMuc/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhmuc);
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