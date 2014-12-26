using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class ContactController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var db = new WebBangDiaEntities();
            ViewBag.MaYC = new SelectList(db.YeuCaus, "MaYC", "TenYeuCau");
            var lienhe = (from lh in db.LienHes orderby lh.MaLH descending select lh).Take(8).ToList();
            string chuoi="";
            for (int i = 0; i < lienhe.Count; i++)
            {
                //var tk=db.TaiKhoans.Where(tk=>tk.MaTK==lienhe[i].MaTK).Select(tk=>tk.TenTK);
                if (lienhe[i].An == null || lienhe[i].An == true)
                {
                    string tentk = lienhe[i].TaiKhoan.HoTen;
                    chuoi += "<div class=\"contentlh\">";
                    chuoi += "<div class=\"dmcontent\">";
                    chuoi += "<div class=\"dmcontentleft\">";
                    chuoi += "<img src=\"/Images/LienHe/anhtk.jpg\"/><br/>";
                    chuoi += "<span>" + tentk + "</span>";
                    chuoi += "</div>";
                    chuoi += "<div class=\"dmcontentright\">";
                    chuoi += "<div>";
                    chuoi += "<h2><a href=\"#\">" + lienhe[i].TieuDe + "</a></h2>";
                    chuoi += "</div>";
                    chuoi += "<p>" + lienhe[i].NoiDung + "</p>";
                    chuoi += "</div>";
                    chuoi += "</div>";
                    chuoi += "</div>";
                }
            }
            ViewBag.lienhe = chuoi;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection, LienHe lienhe)
        {
            int matk;
            if (Session["MaTK"] == "")
            {
                matk = 2;//tai khoan public
            }
            else
            {
                matk = int.Parse(Session["MaTK"].ToString());
            }
            string tieude = collection["txtTitleContact"];
            string noiding = collection["txtContentContact"];
            int mayeucau =int.Parse(collection["MaYC"]);
            DateTime ngaytao = DateTime.Today;

            lienhe.TieuDe=tieude;
            lienhe.NoiDung=noiding;
            lienhe.MaTK=matk;
            lienhe.MaYC=mayeucau;
            lienhe.NgayTao = ngaytao;

            db.LienHes.Add(lienhe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}