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
    public class QTTaiKhoanController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTTaiKhoan/

        public ActionResult Index()
        {
            var taikhoans = db.TaiKhoans.Include(t => t.LoaiTaiKhoan);
            return View(taikhoans.ToList());
        }

        //
        // GET: /QTTaiKhoan/Details/5

        public ActionResult Details(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        //
        // GET: /QTTaiKhoan/Create

        public ActionResult Create()
        {
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK");
            return View();
        }

        //
        // POST: /QTTaiKhoan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }

        //
        // GET: /QTTaiKhoan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }

        //
        // POST: /QTTaiKhoan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }

        //
        // GET: /QTTaiKhoan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        //
        // POST: /QTTaiKhoan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taikhoan);
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