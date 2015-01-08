using System;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class AccountController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        public ActionResult Index()
        {
            if (Session != null)
            {
                if (Session["MaTK"].ToString()!="")
                {
                    int ma = (int)Session["MaTK"];
                    var taikhoans = db.TaiKhoans.Where(t => t.MaTK == ma);
                    return View(taikhoans.ToList());
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                foreach (var taikhoans in db.TaiKhoans)
                {
                    if (taikhoan.TenTK == taikhoans.TenTK && taikhoan.MatKhau == taikhoans.MatKhau)
                    {
                        Session["FullName"] = taikhoans.HoTen;
                        Session["MaTK"] = taikhoans.MaTK;   
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Login");
            }
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Register(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                taikhoan.NgayTao = DateTime.Today;
                taikhoan.An = false;
                taikhoan.MaLoaiTK = 4;
                db.TaiKhoans.Add(taikhoan);
                db.SaveChanges();
                Session["FullName"] = taikhoan.HoTen;
                Session["MaTK"] = taikhoan.MaTK;
                return RedirectToAction("Index","Home");
            }
            
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }
        public ActionResult Logout()
        {
            Session["FullName"] = "bạn!";
            Session["UserName"] = "";
            Session["MaTK"] = "";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Update(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(TaiKhoan taikhoan)
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

        public ActionResult Details(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }
    }
}
