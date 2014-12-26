using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class LoginAccountController : Controller
    {
        //
        // GET: /LoginAccount/
        private WebBangDiaEntities db = new WebBangDiaEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(TaiKhoan taikhoan,FormCollection coll)
        {
            //if (ModelState.IsValid)
            //{
                foreach (var taikhoans in db.TaiKhoans)
                {
                    if (coll["Tentk"] == taikhoans.TenTK && coll["Password"] == taikhoans.MatKhau)
                    {
                        Session["MaTK"] = taikhoans.MaTK;
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Login");
            //}
            //ViewBag.MaLoaiTK = new SelectList(db.LoaiTaiKhoans, "MaLoaiTK", "LoaiTK", taikhoan.MaLoaiTK);
            //return View(taikhoan);
        }
    }
}
