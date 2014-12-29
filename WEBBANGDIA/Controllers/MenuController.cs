using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        WebBangDiaEntities dbEntities = new WebBangDiaEntities();
        public ActionResult MenuLeft()
        {
            ViewBag.MenuLeft = dbEntities.DanhMucs.ToList();
            return PartialView();
        }

        public ActionResult MenuRightLuotXem()
        {
            ViewBag.MenuRightLuotXem = dbEntities.BangDias.ToList().OrderByDescending(s => s.LuotView);
            return PartialView();
        }
    }
}
