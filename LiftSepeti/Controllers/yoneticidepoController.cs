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
    public class yoneticidepoController : Controller
    {
        private LiftSepetiEntities1 db = new LiftSepetiEntities1();

        // GET: yoneticidepo
        public ActionResult Index()
        {
            return View(db.depoTable.ToList());
        }

        // GET: yoneticidepo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            depoTable depoTable = db.depoTable.Find(id);
            if (depoTable == null)
            {
                return HttpNotFound();
            }
            return View(depoTable);
        }

        // GET: yoneticidepo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yoneticidepo/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ad,stok,teminsuresi")] depoTable depoTable)
        {
            if (ModelState.IsValid)
            {
                db.depoTable.Add(depoTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depoTable);
        }

        // GET: yoneticidepo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            depoTable depoTable = db.depoTable.Find(id);
            if (depoTable == null)
            {
                return HttpNotFound();
            }
            return View(depoTable);
        }

        // POST: yoneticidepo/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ad,stok,teminsuresi")] depoTable depoTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depoTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depoTable);
        }

        // GET: yoneticidepo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            depoTable depoTable = db.depoTable.Find(id);
            if (depoTable == null)
            {
                return HttpNotFound();
            }
            return View(depoTable);
        }

        // POST: yoneticidepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            depoTable depoTable = db.depoTable.Find(id);
            db.depoTable.Remove(depoTable);
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
