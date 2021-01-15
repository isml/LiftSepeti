using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models;
using LiftSepeti.Models.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftSepeti.Controllers
{
    public class bayimagazaController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();


        // GET: bayimagaza
        public ActionResult Index(int bayiid)
        {
            bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
            ViewBag.bayibilgiler = bayi;


            ViewBag.bayiid = bayiid;
            var bayiurunler = db.bayiurunlerTable.Where(x => x.bayiid == bayiid).ToList();




            return View(bayiurunler);
        }


        public ActionResult UrunEkle(int bayiid)
        {
            ViewBag.bayiid = bayiid;
            var bayiStok = db.siparisTable.Where(x => x.bayiid == bayiid && x.durumid == 2).ToList();


            bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
            ViewBag.bayibilgiler = bayi;



            return View(bayiStok);
        }
        public ActionResult bayiurunler(int bayiid, int liftid, float satisfiyat)
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

        public ActionResult satislar(int bayiid)
        {
            IEnumerable<musterisiparisModel> musterisiparismodel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5ff8af7517386d0017b5172b.mockapi.io/");
                var responseTask = client.GetAsync("musterisiparis");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<musterisiparisModel>>();
                    readjob.Wait();
                    musterisiparismodel = readjob.Result;
                }
                else
                {
                    //musterisiparismodel = (IEnumerable<yoneticiTable>)Enumerable.Empty<musteriAPIController>();
                    //ModelState.AddModelError(string.Empty, "hataaaaaa");
                }



                ViewBag.bayiid = bayiid;
                bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
                ViewBag.bayibilgiler = bayi;

                return View(musterisiparismodel);
            }



        }
        public ActionResult tariharalik(int tariharaligi, int bayiid)
        {
            if (tariharaligi == 5)
            {
                return RedirectToAction("satislar", "bayimagaza", new { bayiid = bayiid });
            }
            DateTime tarih = DateTime.Now;


            IEnumerable<musterisiparisModel> musterisiparismodel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5ff8af7517386d0017b5172b.mockapi.io/");
                var responseTask = client.GetAsync("musterisiparis");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<musterisiparisModel>>();
                    readjob.Wait();
                    musterisiparismodel = readjob.Result;
                }
                else
                {
                    //musterisiparismodel = (IEnumerable<yoneticiTable>)Enumerable.Empty<musteriAPIController>();
                    //ModelState.AddModelError(string.Empty, "hataaaaaa");
                }

                ViewBag.aralik = tariharaligi;
                ViewBag.ay = tarih.Month;
                ViewBag.gun = tarih.Day;

                ViewBag.bayiid = bayiid;
                return View(musterisiparismodel);
            }

        }

        public ActionResult urunSec(int musteriid,int bayiid)
        {
            ViewBag.musteriid = musteriid;
            ViewBag.musteriad = db.musteriTable.Find(musteriid).ad;
            ViewBag.bayiad = db.bayiTable.Find(bayiid).bayiad;
            ViewBag.bayiid = bayiid;
            var urunler = db.bayiurunlerTable.ToList();
            ViewBag.bayiid = bayiid;
            return View(urunler);
        }
        



    }
}
