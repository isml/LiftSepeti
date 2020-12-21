using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;
namespace LiftSepeti.Controllers
{
    public class anasayfaController : Controller
    {
        // GET: anasayfa
        public ActionResult Index()
        {
            LiftSepetiEntities1 db = new LiftSepetiEntities1();
            var degerler = db.liftTable.ToList();
            return View(degerler);
        }
    }
}