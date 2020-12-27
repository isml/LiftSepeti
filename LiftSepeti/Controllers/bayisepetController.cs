﻿using System;
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
    public class bayisepetController : Controller
    {
        private LiftSepetiEntities1 db = new LiftSepetiEntities1();

        // GET: bayisepet
        public ActionResult Index(int bayiid,int liftid)
        {
            ViewBag.bayiid = bayiid;
            ViewBag.liftid = liftid;
            siparisTable siparis = new siparisTable();
            siparis.bayiid = bayiid;
            siparis.liftid = liftid;
            siparis.durumid = 1;
            siparis.tarih = DateTime.Now;
            siparis.adet = 1.0;
            siparis.odemeyontemiid = 1;
            db.siparisTable.Add(siparis);
            db.SaveChanges();
            var siparisTable = db.siparisTable.Include(s => s.bayiTable).Include(s => s.durumTable).Include(s => s.liftTable).Include(s => s.odemeyontemiTable);
            return View(siparisTable.ToList());
        }
        public ActionResult getIndex(int bayiid)
        {
           
            var siparisTable = db.siparisTable.Include(s => s.bayiTable).Include(s => s.durumTable).Include(s => s.liftTable).Include(s => s.odemeyontemiTable);
            return View(siparisTable.ToList());
        }

        // GET: bayisepet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siparisTable siparisTable = db.siparisTable.Find(id);
            if (siparisTable == null)
            {
                return HttpNotFound();
            }
            return View(siparisTable);
        }

        // GET: bayisepet/Create
        public ActionResult Create()
        {
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke");
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum");
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim");
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip");
            return View();
        }

        // POST: bayisepet/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bayiid,liftid,durumid,tarih,adet,odemeyontemiid")] siparisTable siparisTable)
        {
            if (ModelState.IsValid)
            {
                db.siparisTable.Add(siparisTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }

        // GET: bayisepet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siparisTable siparisTable = db.siparisTable.Find(id);
            if (siparisTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }

        // POST: bayisepet/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bayiid,liftid,durumid,tarih,adet,odemeyontemiid")] siparisTable siparisTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparisTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }

        // GET: bayisepet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siparisTable siparisTable = db.siparisTable.Find(id);
            if (siparisTable == null)
            {
                return HttpNotFound();
            }
            return View(siparisTable);
        }

        // POST: bayisepet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            siparisTable siparisTable = db.siparisTable.Find(id);
            db.siparisTable.Remove(siparisTable);
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