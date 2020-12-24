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
    public class bayimagazaController : Controller
    {
        private LiftSepetiEntities1 db = new LiftSepetiEntities1();

        // GET: bayimagaza
        public ActionResult Index(int bayiid)
        {
            var bayiurunlerTable = db.bayiurunlerTable.Include(b => b.bayiTable).Include(b => b.modelTable);
            return View(bayiurunlerTable.ToList());
        }

        // GET: bayimagaza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiurunlerTable bayiurunlerTable = db.bayiurunlerTable.Find(id);
            if (bayiurunlerTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiurunlerTable);
        }

        // GET: bayimagaza/Create
        public ActionResult Create()
        {
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke");
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad");
            return View();
        }

        // POST: bayimagaza/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bayiid,modelid,stok,fiyat")] bayiurunlerTable bayiurunlerTable)
        {
            if (ModelState.IsValid)
            {
                db.bayiurunlerTable.Add(bayiurunlerTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", bayiurunlerTable.bayiid);
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad", bayiurunlerTable.modelid);
            return View(bayiurunlerTable);
        }

        // GET: bayimagaza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiurunlerTable bayiurunlerTable = db.bayiurunlerTable.Find(id);
            if (bayiurunlerTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", bayiurunlerTable.bayiid);
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad", bayiurunlerTable.modelid);
            return View(bayiurunlerTable);
        }

        // POST: bayimagaza/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bayiid,modelid,stok,fiyat")] bayiurunlerTable bayiurunlerTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bayiurunlerTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", bayiurunlerTable.bayiid);
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad", bayiurunlerTable.modelid);
            return View(bayiurunlerTable);
        }

        // GET: bayimagaza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiurunlerTable bayiurunlerTable = db.bayiurunlerTable.Find(id);
            if (bayiurunlerTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiurunlerTable);
        }

        // POST: bayimagaza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bayiurunlerTable bayiurunlerTable = db.bayiurunlerTable.Find(id);
            db.bayiurunlerTable.Remove(bayiurunlerTable);
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
