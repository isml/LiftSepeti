using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;
namespace LiftSepeti.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LiftSepetiEntities1 db = new LiftSepetiEntities1();
            var degerler = db.liftTable.ToList();       
            return View(degerler);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}