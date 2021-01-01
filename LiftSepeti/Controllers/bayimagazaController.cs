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
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();
         

        // GET: bayimagaza
        public ActionResult Index(int bayiid)
        {
            ViewBag.bayiid = bayiid;           
            var bayiurunler = db.bayiurunlerTable.Where(x => x.bayiid == bayiid).ToList();       
            return View(bayiurunler);
        }

       
        public ActionResult UrunEkle(int bayiid)
        {
            ViewBag.bayiid = bayiid;
            var bayiStok =  db.siparisTable.Where(x => x.bayiid == bayiid&&x.durumid==2).ToList();
            return View(bayiStok);
        }
        public ActionResult bayiurunler(int bayiid,int liftid,float satisfiyat)
        {
            ViewBag.bayiid = bayiid;
            bayiurunlerTable bayiurun = new bayiurunlerTable();
            bayiurun.bayiid = bayiid;
            bayiurun.liftid = liftid;
            bayiurun.fiyat = satisfiyat;
            bayiurun.stok = 1;
            db.bayiurunlerTable.Add(bayiurun);
            db.SaveChanges();
           
            var bayiurunler = db.bayiurunlerTable.Where(x => x.bayiid == bayiid).ToList();
            return RedirectToAction("Index", "bayimagaza", new { bayiid = bayiid });

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
       

        // GET: bayimagaza/Edit/5
       

        // POST: bayimagaza/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
      

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
