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
    public class QTQuocGiaController : Controller
    {
        private WebBangDiaEntities db = new WebBangDiaEntities();

        //
        // GET: /QTQuocGia/

        public ActionResult Index()
        {
            return View(db.QuocGias.ToList());
        }

        //
        // GET: /QTQuocGia/Details/5

        public ActionResult Details(int id = 0)
        {
            QuocGia quocgia = db.QuocGias.Find(id);
            if (quocgia == null)
            {
                return HttpNotFound();
            }
            return View(quocgia);
        }

        //
        // GET: /QTQuocGia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QTQuocGia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuocGia quocgia)
        {
            if (ModelState.IsValid)
            {
                db.QuocGias.Add(quocgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quocgia);
        }

        //
        // GET: /QTQuocGia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            QuocGia quocgia = db.QuocGias.Find(id);
            if (quocgia == null)
            {
                return HttpNotFound();
            }
            return View(quocgia);
        }

        //
        // POST: /QTQuocGia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuocGia quocgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quocgia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quocgia);
        }

        //
        // GET: /QTQuocGia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            QuocGia quocgia = db.QuocGias.Find(id);
            if (quocgia == null)
            {
                return HttpNotFound();
            }
            return View(quocgia);
        }

        //
        // POST: /QTQuocGia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuocGia quocgia = db.QuocGias.Find(id);
            db.QuocGias.Remove(quocgia);
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