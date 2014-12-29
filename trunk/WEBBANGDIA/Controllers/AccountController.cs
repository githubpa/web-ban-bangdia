using System;
using System.Linq;
using System.Web.Mvc;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class AccountController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                foreach (var taikhoans in db.TaiKhoans)
                {
                    if (taikhoan.TenTK == taikhoans.TenTK && taikhoan.MatKhau == taikhoans.MatKhau)
                    {
                        Session["FullName"] = taikhoan.TenTK;
                        Session["MaTK"] = taikhoan.MaTK;
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
                Session["FullName"] = taikhoan.TenTK;
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
            return RedirectToAction("Index", "Home");
        }
    }
}
