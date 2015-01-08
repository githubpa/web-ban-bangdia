using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using WEBBANGDIA.Models;


namespace WEBBANGDIA.Controllers
{
    public class LogQTController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();
        //
        // GET: /LogQT/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                foreach (var taikhoans in db.TaiKhoans)
                {
                    if (taikhoan.TenTK == taikhoans.TenTK && taikhoan.MatKhau == taikhoans.MatKhau && taikhoans.MaLoaiTK==1 && taikhoans.An == false || taikhoans.An == null  )
                        Session["LogedName"] = taikhoans.HoTen;
                        return RedirectToAction("Index", "QTTaiKhoan");
                }
                return RedirectToAction("Login");
            }
            ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            return View(taikhoan);
        }

    }
}
