using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBBANGDIA.Models;

namespace WEBBANGDIA.Controllers
{
    public class QTChatLuongDiaController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTChatLuongDia/

        public ActionResult Index()
        {
            return View(db.ChatLuongs.ToList());
        }

        //
        // GET: /QTChatLuongDia/Details/5

        public ActionResult Details(int id = 0)
        {
            ChatLuong chatluong = db.ChatLuongs.Find(id);
            if (chatluong == null)
            {
                return HttpNotFound();
            }
            return View(chatluong);
        }

        //
        // GET: /QTChatLuongDia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QTChatLuongDia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChatLuong chatluong)
        {
            if (ModelState.IsValid)
            {
                db.ChatLuongs.Add(chatluong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatluong);
        }

        //
        // GET: /QTChatLuongDia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChatLuong chatluong = db.ChatLuongs.Find(id);
            if (chatluong == null)
            {
                return HttpNotFound();
            }
            return View(chatluong);
        }

        //
        // POST: /QTChatLuongDia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChatLuong chatluong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatluong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatluong);
        }

        //
        // GET: /QTChatLuongDia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChatLuong chatluong = db.ChatLuongs.Find(id);
            if (chatluong == null)
            {
                return HttpNotFound();
            }
            return View(chatluong);
        }

        //
        // POST: /QTChatLuongDia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatLuong chatluong = db.ChatLuongs.Find(id);
            db.ChatLuongs.Remove(chatluong);
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