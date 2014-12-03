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
    public class QTLoaiTaiKhoanController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTLoaiTaiKhoan/

        public ActionResult Index()
        {
            return View(db.LoaiTaiKhoans.ToList());
        }

        //
        // GET: /QTLoaiTaiKhoan/Details/5

        public ActionResult Details(int id = 0)
        {
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            if (loaitaikhoan == null)
            {
                return HttpNotFound();
            }
            return View(loaitaikhoan);
        }

        //
        // GET: /QTLoaiTaiKhoan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QTLoaiTaiKhoan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiTaiKhoan loaitaikhoan)
        {
            if (ModelState.IsValid)
            {
                db.LoaiTaiKhoans.Add(loaitaikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaitaikhoan);
        }

        //
        // GET: /QTLoaiTaiKhoan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            if (loaitaikhoan == null)
            {
                return HttpNotFound();
            }
            return View(loaitaikhoan);
        }

        //
        // POST: /QTLoaiTaiKhoan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiTaiKhoan loaitaikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaitaikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaitaikhoan);
        }

        //
        // GET: /QTLoaiTaiKhoan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            if (loaitaikhoan == null)
            {
                return HttpNotFound();
            }
            return View(loaitaikhoan);
        }

        //
        // POST: /QTLoaiTaiKhoan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            db.LoaiTaiKhoans.Remove(loaitaikhoan);
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