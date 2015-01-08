using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using WEBBANGDIA.Models;
using PagedList;

namespace WEBBANGDIA.Controllers
{
    public class HomeController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var db = new WebBangDiaEntities();
            const int pageSize = 12;
            int pageNum = page ?? 1;
            var id = int.Parse(Session["Home"].ToString());
            if (id == 1)
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderBy(p => p.TenBD);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderBy(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }
        [HttpPost]
        public ActionResult Index(FormCollection form, int? page)
        {
            const int pageSize = 12;
            int pageNum = page ?? 1;
            Session["Home"] = Convert.ToInt32(form["dropdown"]);
            var id = int.Parse(Session["Home"].ToString());
            if (id == 1)
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderBy(p => p.TenBD);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderBy(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = db.BangDias.Where(sp => sp.An != true).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }

        [HttpGet]
        public ActionResult All(int idDm, int? page)
        {
            var db = new WebBangDiaEntities();
            const int pageSize = 12;
            int pageNum = page ?? 1;
            var id = int.Parse(Session["Home"].ToString());
            if (id == 1)
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderBy(p => p.TenBD);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderBy(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }
        [HttpPost]
        public ActionResult All(FormCollection form, int idDm, int? page)
        {
            const int pageSize = 12;
            int pageNum = page ?? 1;
            Session["Home"] = Convert.ToInt32(form["dropdown"]);
            var id = int.Parse(Session["Home"].ToString());
            if (id == 1)
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderBy(p => p.TenBD);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderBy(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = db.BangDias.Where(sp => sp.An != true & sp.DanhMuc.MaDM == idDm).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }

        public ActionResult Details(int id = 0)
        {
            BangDia bangdia = db.BangDias.Find(id);
            if (bangdia == null)
            {
                return HttpNotFound();
            }
            bangdia.LuotView = bangdia.LuotView + 1;
            if (ModelState.IsValid)
            {
                db.Entry(bangdia).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(bangdia);
        }

        public ActionResult Order(int id = 0)
        {
            BangDia bangdia = db.BangDias.Find(id);
            if (bangdia == null)
            {
                return HttpNotFound();
            }
            bangdia.LuotView = bangdia.LuotView + 1;
            if (ModelState.IsValid)
            {
                db.Entry(bangdia).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(bangdia);
        }

        [HttpGet]
        public ActionResult Search(int? page)
        {
            string keyword = Session["search"].ToString();
            var dbEntities = new WebBangDiaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var listProduct = dbEntities.BangDias.Where(sp => sp.An != true & sp.TenBD.Contains(keyword)).OrderByDescending(sp => sp.TenBD);
            return View(listProduct.ToPagedList(pageNum, pageSize));
        }

        [HttpPost]
        public ActionResult Search(FormCollection form, int? page)
        {
            Session["search"] = form["txtText"];
            string keyword = form["txtText"];
            var dbEntities = new WebBangDiaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var listProduct =
                dbEntities.BangDias.Where(sp => sp.An != true & sp.TenBD.Contains(keyword)).OrderByDescending(sp => sp.TenBD);
            return View(listProduct.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Mua(int id)
        {
            if (Session["MaTK"].ToString() == "" || Session["MaTK"].ToString() == "2")
            {
                Session["Error"] = "Bạn chưa đăng nhập ! Hãy đăng nhập để đặt hàng.";
                Response.Redirect(@"~\Home\Error");
            }
            else
            {
                var bangdia = db.BangDias.Find(id);
                var dathang = new DatHang();
                dathang.MaLoaiHinh = 1;
                dathang.MaTK = Convert.ToInt32(Session["MaTK"].ToString());
                dathang.MaBD = id;
                dathang.NgayDat = DateTime.Today;
                bangdia.LuotBan = bangdia.LuotBan + 1;
                dathang.GiaHan = 0;
                dathang.Tra = false;
                if (ModelState.IsValid)
                {
                    db.Entry(bangdia).State = EntityState.Modified;
                    db.DatHangs.Add(dathang);
                    db.SaveChanges();
                }
                return View(dathang);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Thue(int id)
        {
            if (Session["MaTK"].ToString() == "" || Session["MaTK"].ToString() == "2")
            {
                Session["Error"] = "Bạn chưa đăng nhập ! Hãy đăng nhập để đặt hàng.";
                Response.Redirect(@"~\Home\Error");
            }
            else
            {
                var dathang = new DatHang();
                var bangdia = db.BangDias.Find(id);
                bangdia.LuotThue = bangdia.LuotThue + 1;
                dathang.MaLoaiHinh = 2;
                dathang.MaTK = Convert.ToInt32(Session["MaTK"].ToString());
                dathang.MaBD = id;
                dathang.Tra = false;
                dathang.NgayDat = DateTime.Today;
                dathang.GiaHan = 1;
                if (ModelState.IsValid)
                {
                    db.Entry(bangdia).State = EntityState.Modified;
                    db.DatHangs.Add(dathang);
                    db.SaveChanges();
                }
                return View(dathang);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Filter()
        {
            return View();
        }

        public double CanDuoiGia(int magia)
        {
            switch (magia)
            {
                case 0:
                    return 0;
                case 1:
                    return 500000;
                case 2:
                    return 0;
                default:
                    return 100000;
            }
        }

        public double CanTrenGia(int magia)
        {
            switch (magia)
            {
                case 0:
                    return 500000;
                case 1:
                    return Int32.MaxValue;
                case 2:
                    return 100000;
                default:
                    return Int32.MaxValue;
            }
        }

        public int CanDuoiXem(int maxem)
        {
            switch (maxem)
            {
                case 2:
                    return 0;
                case 3:
                    return 100;
                case 4:
                    return 0;
                default:
                    return 1000;
            }
        }

        public int CanTrenXem(int maxem)
        {
            switch (maxem)
            {
                case 2:
                    return 100;
                case 3:
                    return Int32.MaxValue;
                case 4:
                    return 1000;
                default:
                    return Int32.MaxValue;
            }
        }

        [HttpPost]
        public ActionResult Filter(FormCollection form, int? page)
        {
            var dbEntities = new WebBangDiaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            Session["Gia"] = Convert.ToInt32(form["dropdownGia"]);
            Session["Xem"] = Convert.ToInt32(form["dropdownXem"]);
            Session["TheLoai"] = Convert.ToInt32(form["dropdownTheLoai"]);
            Session["Hsx"] = Convert.ToInt32(form["dropdownHsx"]);
            var idG = Convert.ToInt32(Session["Gia"].ToString());
            var idX = Convert.ToInt32(Session["Xem"].ToString());
            var idT = Convert.ToInt32(Session["TheLoai"].ToString());
            var idH = Convert.ToInt32(Session["Hsx"].ToString());
            if ((idG == 4 || idG == 5) && (idX == 0 || idX == 1))
            {
                if (idG == 4 && idX == 0)
                {
                    var listProduct =
                        dbEntities.BangDias.Where(sp => sp.An != true & sp.MaDM == idT & sp.MaHSX == idH)
                            .OrderBy(sp => sp.Gia)
                            .ThenByDescending(sp => sp.LuotView);
                    return View(listProduct.ToPagedList(pageNum, pageSize));
                }
                else if (idG == 5 && idX == 0)
                {
                    var listProduct =
                        dbEntities.BangDias.Where(sp => sp.An != true & sp.MaDM == idT & sp.MaHSX == idH)
                            .OrderByDescending(sp => sp.Gia)
                            .ThenByDescending(sp => sp.LuotView);
                    return View(listProduct.ToPagedList(pageNum, pageSize));
                }
                else if (idG == 4 && idX == 1)
                {
                    var listProduct =
                        dbEntities.BangDias.Where(sp => sp.An != true & sp.MaDM == idT & sp.MaHSX == idH)
                            .OrderBy(sp => sp.Gia)
                            .ThenBy(sp => sp.LuotView);
                    return View(listProduct.ToPagedList(pageNum, pageSize));
                }
                else if (idG == 5 && idX == 1)
                {
                    var listProduct =
                        dbEntities.BangDias.Where(sp => sp.An != true & sp.MaDM == idT & sp.MaHSX == idH)
                            .OrderBy(sp => sp.Gia)
                            .ThenBy(sp => sp.LuotView);
                    return View(listProduct.ToPagedList(pageNum, pageSize));
                }
            }
            else
            {
                double ctG = CanTrenGia(idG);
                double cdG = CanDuoiGia(idG);
                double ctX = CanTrenXem(idX);
                double cdX = CanDuoiXem(idX);
                var listProduct2 =
                    dbEntities.BangDias.Where(
                        sp =>
                            sp.An != true & sp.MaDM == idT & sp.MaHSX == idH & sp.Gia > cdG &
                            sp.Gia <= ctG & sp.LuotView > cdX & sp.LuotView <= ctX).OrderByDescending(sp => sp.Gia);
                return View(listProduct2.ToPagedList(pageNum, pageSize));
            }
            var list = db.BangDias.Where(sp => sp.An != true).OrderByDescending(p => p.Gia);
            return View(list.ToPagedList(pageNum, pageSize));
        }
    }
}
