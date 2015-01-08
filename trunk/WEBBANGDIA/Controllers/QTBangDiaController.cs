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
    public class QTBangDiaController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTBangDia/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? trang)
        {
            if (Session["LogedName"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.TypedickSortParm = sortOrder == "Loai" ? "loai_desc" : "Loai";
                ViewBag.ViewSortParm = sortOrder == "LuotView" ? "luotview_desc" : "LuotView";
                ViewBag.PriceSortParm = sortOrder == "Gia" ? "gia_desc" : "Gia";
                ViewBag.HSXSortParm = sortOrder == "HSX" ? "HSX_desc" : "HSX";
                ViewBag.BuySortParm = sortOrder == "Buy" ? "Buy_desc" : "Buy";
                ViewBag.ThueSortParm = sortOrder == "Thue" ? "Thue_desc" : "Thue";
                if (searchString != null)
                {
                    trang = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var sanphams = from s in db.BangDias
                               select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    sanphams = sanphams.Where(s => s.TenBD.ToUpper().Contains(searchString.ToUpper())
                        || s.LoaiDia.TenLoai.ToUpper().Contains(searchString.ToUpper()));
                }
                switch (sortOrder)
                {
                    case "HSX":
                        sanphams = sanphams.OrderBy(s => s.HangSanXuat.TenHSX);
                        break;
                    case "HSX_desc":
                        sanphams = sanphams.OrderByDescending(s => s.HangSanXuat.TenHSX);
                        break; ;
                    case "Buy":
                        sanphams = sanphams.OrderBy(s => s.LuotBan);
                        break;
                    case "Buy_desc":
                        sanphams = sanphams.OrderByDescending(s => s.LuotBan);
                        break; ;
                    case "Thue":
                        sanphams = sanphams.OrderBy(s => s.LuotThue);
                        break;
                    case "Thue_desc":
                        sanphams = sanphams.OrderByDescending(s => s.LuotThue);
                        break; ;
                    case "name_desc":
                        sanphams = sanphams.OrderByDescending(s => s.TenBD);
                        break;
                    case "LuotView":
                        sanphams = sanphams.OrderBy(s => s.LuotView);
                        break;
                    case "luotview_desc":
                        sanphams = sanphams.OrderByDescending(s => s.LuotView);
                        break;
                    case "Loai":
                        sanphams = sanphams.OrderBy(s => s.LoaiDia.TenLoai);
                        break;
                    case "loai_desc":
                        sanphams = sanphams.OrderByDescending(s => s.LoaiDia.TenLoai);
                        break;
                    case "Gia":
                        sanphams = sanphams.OrderBy(s => s.Gia);
                        break;
                    case "gia_desc":
                        sanphams = sanphams.OrderByDescending(s => s.Gia);
                        break;
                    default:  // Name ascending 
                        sanphams = sanphams.OrderBy(s => s.TenBD);
                        break;
                }
                const int pageSize = 15;
                int pageNum = trang ?? 1;

                return View(sanphams.ToPagedList(pageNum, pageSize));
            }
            return RedirectToAction("Login", "LogQT");
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
        [ValidateInput(false)]
        public ActionResult Create(BangDia bangdia)
        {
            if (ModelState.IsValid)
            {
                bangdia.NgayCapNhat = DateTime.Today;
                bangdia.LuotThue = 0;
                bangdia.LuotBan = 0;
                bangdia.LuotView = 0;
                bangdia.NgayTao = DateTime.Today;
                bangdia.AnhDaiDien = bangdia.AnhDaiDien.Replace("/Images/","");
                bangdia.An = false;
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
            int a = bangdia.MaBD;
            if (ModelState.IsValid)
            {
                if (bangdia.An == true)
                {
                    bangdia.NgayCapNhat = DateTime.Today;;
                }
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