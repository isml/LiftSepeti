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
    public class musteriAPIController : Controller
    {
        // GET: musteriAPI
        public ActionResult Index()
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
                return View(musterisiparismodel);
            }



        }
        public ActionResult SiparisEkle(int musteriid, int bayiid, int liftid, int modelid, string resim, string bayiad, string liftad, double fiyat, int bakimperiyot)
        {
            musterisiparisModel musterisiparis = new musterisiparisModel();
            musterisiparis.id = musteriid;
            musterisiparis.bayiid = bayiid;
            musterisiparis.liftid = liftid;
            musterisiparis.modelid = modelid;
            musterisiparis.resim = resim;
            musterisiparis.bayiad = bayiad;
            musterisiparis.liftad = liftad;
            musterisiparis.fiyat = fiyat;
            musterisiparis.bakimperiyot = bakimperiyot;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5ff8af7517386d0017b5172b.mockapi.io/musterisiparis");
                var postJob = client.PostAsJsonAsync<musterisiparisModel>("musterisiparis", musterisiparis);
                postJob.Wait();

                var result = postJob.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //musterisiparismodel = (IEnumerable<yoneticiTable>)Enumerable.Empty<musteriAPIController>();
                    //ModelState.AddModelError(string.Empty, "hataaaaaa");
                    return RedirectToAction("Index");
                }

            }



        }
    }
}