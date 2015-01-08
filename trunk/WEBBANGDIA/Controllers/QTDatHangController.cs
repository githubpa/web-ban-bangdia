using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class QTDatHangController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTDatHang/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? trang)
        {
            if (Session["LogedName"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
                ViewBag.NameLhSortParm = sortOrder == "NameLh" ? "NameLh_desc" : "NameLh";
                ViewBag.NameBdSortParm = sortOrder == "NameBd" ? "NameBd_desc" : "NameBd";
                ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
                ViewBag.TraSortParm = sortOrder == "Tra" ? "Tra_desc" : "Tra";
                if (searchString != null)
                {
                    trang = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var dathangs = from s in db.DatHangs
                               select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    dathangs = dathangs.Where(s => s.BangDia.TenBD.ToUpper().Contains(searchString.ToUpper()));
                }
                switch (sortOrder)
                {
                    case "NameLh":
                        dathangs = dathangs.OrderBy(s => s.LoaiHinhGiaoDich.TenLoaiHinh);
                        break;
                    case "NameLh_desc":
                        dathangs = dathangs.OrderByDescending(s => s.LoaiHinhGiaoDich.TenLoaiHinh);
                        break;
                    case "NameBd":
                        dathangs = dathangs.OrderBy(s => s.BangDia.TenBD);
                        break;
                    case "NameBd_desc":
                        dathangs = dathangs.OrderByDescending(s => s.BangDia.TenBD);
                        break;
                    case "Date":
                        dathangs = dathangs.OrderBy(s => s.NgayDat);
                        break;
                    case "Date_desc":
                        dathangs = dathangs.OrderByDescending(s => s.NgayDat);
                        break;
                    case "Tra":
                        dathangs = dathangs.OrderBy(s => s.Tra);
                        break;
                    case "Tra_desc":
                        dathangs = dathangs.OrderByDescending(s => s.Tra);
                        break;
                    case "Name":
                        dathangs = dathangs.OrderBy(s => s.TaiKhoan.TenTK);
                        break;
                    case "Name_desc":
                        dathangs = dathangs.OrderByDescending(s => s.TaiKhoan.TenTK);
                        break;
                    default:  // Name ascending 
                        dathangs = dathangs.OrderBy(s => s.BangDia.TenBD);
                        break;
                }
                const int pageSize = 15;
                int pageNum = trang ?? 1;

                return View(dathangs.ToPagedList(pageNum, pageSize));
            }
            return RedirectToAction("Login", "LogQT");
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
                dathang.NgayDat = DateTime.Today;
                dathang.GiaHan = 1;
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
                if (dathang.Tra == true)
                {
                    dathang.NgayTra = DateTime.Today;
                }
                db.Entry(dathang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBD = new SelectList(db.BangDias, "MaBD", "TenBD", dathang.MaBD);
            ViewBag.MaLoaiHinh = new SelectList(db.LoaiHinhGiaoDiches, "MaLoaiHinh", "TenLoaiHinh", dathang.MaLoaiHinh);
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "TenTK", dathang.MaTK);
            return View(dathang);
        }

        public ActionResult GiaHan(int id = 0)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GiaHan(DatHang dathang)
        {
            if (ModelState.IsValid)
            {
                dathang.GiaHan = dathang.GiaHan+1;
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