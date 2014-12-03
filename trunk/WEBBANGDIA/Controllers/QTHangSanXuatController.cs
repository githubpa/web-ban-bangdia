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
    public class QTHangSanXuatController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTHangSanXuat/

        public ActionResult Index()
        {
            var hangsanxuats = db.HangSanXuats.Include(h => h.QuocGia);
            return View(hangsanxuats.ToList());
        }

        //
        // GET: /QTHangSanXuat/Details/5

        public ActionResult Details(int id = 0)
        {
            HangSanXuat hangsanxuat = db.HangSanXuats.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        //
        // GET: /QTHangSanXuat/Create

        public ActionResult Create()
        {
            ViewBag.MaQG = new SelectList(db.QuocGias, "MaQG", "TenQG");
            return View();
        }

        //
        // POST: /QTHangSanXuat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HangSanXuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.HangSanXuats.Add(hangsanxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaQG = new SelectList(db.QuocGias, "MaQG", "TenQG", hangsanxuat.MaQG);
            return View(hangsanxuat);
        }

        //
        // GET: /QTHangSanXuat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            HangSanXuat hangsanxuat = db.HangSanXuats.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQG = new SelectList(db.QuocGias, "MaQG", "TenQG", hangsanxuat.MaQG);
            return View(hangsanxuat);
        }

        //
        // POST: /QTHangSanXuat/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HangSanXuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangsanxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaQG = new SelectList(db.QuocGias, "MaQG", "TenQG", hangsanxuat.MaQG);
            return View(hangsanxuat);
        }

        //
        // GET: /QTHangSanXuat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            HangSanXuat hangsanxuat = db.HangSanXuats.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        //
        // POST: /QTHangSanXuat/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangSanXuat hangsanxuat = db.HangSanXuats.Find(id);
            db.HangSanXuats.Remove(hangsanxuat);
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