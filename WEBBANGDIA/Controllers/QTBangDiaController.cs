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
    public class QTBangDiaController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTBangDia/

        public ActionResult Index()
        {
            var bangdias = db.BangDias.Include(b => b.ChatLuong).Include(b => b.DanhMuc).Include(b => b.HangSanXuat).Include(b => b.LoaiDia);
            return View(bangdias.ToList());
        }

        //
        // GET: /QTBangDia/Details/5

        public ActionResult Details(int id = 0)
        {
            BangDia bangdia = db.BangDias.Find(id);
            if (bangdia == null)
            {
                return HttpNotFound();
            }
            return View(bangdia);
        }

        //
        // GET: /QTBangDia/Create

        public ActionResult Create()
        {
            ViewBag.MaCL = new SelectList(db.ChatLuongs, "MaCL", "TenCL");
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc");
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
            ViewBag.MaLoai = new SelectList(db.LoaiDias, "MaLoai", "TenLoai");
            return View();
        }

        //
        // POST: /QTBangDia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BangDia bangdia)
        {
            if (ModelState.IsValid)
            {
                db.BangDias.Add(bangdia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCL = new SelectList(db.ChatLuongs, "MaCL", "TenCL", bangdia.MaCL);
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc", bangdia.MaDM);
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", bangdia.MaHSX);
            ViewBag.MaLoai = new SelectList(db.LoaiDias, "MaLoai", "TenLoai", bangdia.MaLoai);
            return View(bangdia);
        }

        //
        // GET: /QTBangDia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BangDia bangdia = db.BangDias.Find(id);
            if (bangdia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCL = new SelectList(db.ChatLuongs, "MaCL", "TenCL", bangdia.MaCL);
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc", bangdia.MaDM);
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", bangdia.MaHSX);
            ViewBag.MaLoai = new SelectList(db.LoaiDias, "MaLoai", "TenLoai", bangdia.MaLoai);
            return View(bangdia);
        }

        //
        // POST: /QTBangDia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BangDia bangdia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangdia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCL = new SelectList(db.ChatLuongs, "MaCL", "TenCL", bangdia.MaCL);
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc", bangdia.MaDM);
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", bangdia.MaHSX);
            ViewBag.MaLoai = new SelectList(db.LoaiDias, "MaLoai", "TenLoai", bangdia.MaLoai);
            return View(bangdia);
        }

        //
        // GET: /QTBangDia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BangDia bangdia = db.BangDias.Find(id);
            if (bangdia == null)
            {
                return HttpNotFound();
            }
            return View(bangdia);
        }

        //
        // POST: /QTBangDia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangDia bangdia = db.BangDias.Find(id);
            db.BangDias.Remove(bangdia);
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