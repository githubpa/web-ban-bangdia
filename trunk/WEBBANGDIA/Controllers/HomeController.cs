using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
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
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderBy(p => p.TenBD);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = db.BangDias.Where(sp => sp.An == false || sp.An==null).OrderBy(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderByDescending(p => p.NgayCapNhat);
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
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderBy(p => p.TenBD);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderBy(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = db.BangDias.Where(sp => sp.An == false || sp.An == null).OrderByDescending(p => p.NgayCapNhat);
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
            return View(bangdia);
        }
    }
}
