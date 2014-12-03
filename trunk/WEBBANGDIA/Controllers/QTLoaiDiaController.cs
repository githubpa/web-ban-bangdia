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
    public class QTLoaiDiaController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTLoaiDia/

        public ActionResult Index()
        {
            return View(db.LoaiDias.ToList());
        }

        //
        // GET: /QTLoaiDia/Details/5

        public ActionResult Details(int id = 0)
        {
            LoaiDia loaidia = db.LoaiDias.Find(id);
            if (loaidia == null)
            {
                return HttpNotFound();
            }
            return View(loaidia);
        }

        //
        // GET: /QTLoaiDia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QTLoaiDia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiDia loaidia)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDias.Add(loaidia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaidia);
        }

        //
        // GET: /QTLoaiDia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LoaiDia loaidia = db.LoaiDias.Find(id);
            if (loaidia == null)
            {
                return HttpNotFound();
            }
            return View(loaidia);
        }

        //
        // POST: /QTLoaiDia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiDia loaidia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaidia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaidia);
        }

        //
        // GET: /QTLoaiDia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LoaiDia loaidia = db.LoaiDias.Find(id);
            if (loaidia == null)
            {
                return HttpNotFound();
            }
            return View(loaidia);
        }

        //
        // POST: /QTLoaiDia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiDia loaidia = db.LoaiDias.Find(id);
            db.LoaiDias.Remove(loaidia);
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