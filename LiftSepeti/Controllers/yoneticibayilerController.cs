using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;

namespace LiftSepeti.Controllers
{
    public class yoneticibayilerController : Controller
    {
        private LiftSepetiEntities1 db = new LiftSepetiEntities1();

        // GET: yoneticibayiler
        public ActionResult Index()
        {
            return View(db.bayiTable.ToList());
        }

        // GET: yoneticibayiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiTable bayiTable = db.bayiTable.Find(id);
            if (bayiTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiTable);
        }

        // GET: yoneticibayiler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yoneticibayiler/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ulke,sehir,bayiad,sifre")] bayiTable bayiTable)
        {
            if (ModelState.IsValid)
            {
                db.bayiTable.Add(bayiTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bayiTable);
        }

        // GET: yoneticibayiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiTable bayiTable = db.bayiTable.Find(id);
            if (bayiTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiTable);
        }

        // POST: yoneticibayiler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ulke,sehir,bayiad,sifre")] bayiTable bayiTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bayiTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bayiTable);
        }

        // GET: yoneticibayiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiTable bayiTable = db.bayiTable.Find(id);
            if (bayiTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiTable);
        }

        // POST: yoneticibayiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bayiTable bayiTable = db.bayiTable.Find(id);
            db.bayiTable.Remove(bayiTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
