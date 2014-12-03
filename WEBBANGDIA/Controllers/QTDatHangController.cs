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
    public class QTDatHangController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTDatHang/

        public ActionResult Index()
        {
            var dathangs = db.DatHangs.Include(d => d.BangDia).Include(d => d.LoaiHinhGiaoDich).Include(d => d.TaiKhoan);
            return View(dathangs.ToList());
        }

        //
        // GET: /QTDatHang/Details/5

        public ActionResult Details(int id = 0)
        {
            DatHang dathang = db.DatHangs.Find(id);
            if (dathang == null)
            {
                return HttpNotFound();
            }
            return View(dathang);
        }

        //
        // GET: /QTDatHang/Create

        public ActionResult Create()
        {
            ViewBag.MaBD = new SelectList(db.BangDias, "MaBD", "TenBD");
            ViewBag.MaLoaiHinh = new SelectList(db.LoaiHinhGiaoDiches, "MaLoaiHinh", "TenLoaiHinh");
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK");
            return View();
        }

        //
        // POST: /QTDatHang/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DatHang dathang)
        {
            if (ModelState.IsValid)
            {
                db.DatHangs.Add(dathang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBD = new SelectList(db.BangDias, "MaBD", "TenBD", dathang.MaBD);
            ViewBag.MaLoaiHinh = new SelectList(db.LoaiHinhGiaoDiches, "MaLoaiHinh", "TenLoaiHinh", dathang.MaLoaiHinh);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", dathang.MaTK);
            return View(dathang);
        }

        //
        // GET: /QTDatHang/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DatHang dathang = db.DatHangs.Find(id);
            if (dathang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBD = new SelectList(db.BangDias, "MaBD", "TenBD", dathang.MaBD);
            ViewBag.MaLoaiHinh = new SelectList(db.LoaiHinhGiaoDiches, "MaLoaiHinh", "TenLoaiHinh", dathang.MaLoaiHinh);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", dathang.MaTK);
            return View(dathang);
        }

        //
        // POST: /QTDatHang/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DatHang dathang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dathang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBD = new SelectList(db.BangDias, "MaBD", "TenBD", dathang.MaBD);
            ViewBag.MaLoaiHinh = new SelectList(db.LoaiHinhGiaoDiches, "MaLoaiHinh", "TenLoaiHinh", dathang.MaLoaiHinh);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", dathang.MaTK);
            return View(dathang);
        }

        //
        // GET: /QTDatHang/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DatHang dathang = db.DatHangs.Find(id);
            if (dathang == null)
            {
                return HttpNotFound();
            }
            return View(dathang);
        }

        //
        // POST: /QTDatHang/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatHang dathang = db.DatHangs.Find(id);
            db.DatHangs.Remove(dathang);
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