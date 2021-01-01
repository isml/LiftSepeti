﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;


namespace LiftSepeti.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        LiftSepetiEntities4 db = new LiftSepetiEntities4();
        public ActionResult Index()
        {
            var degerler = db.musteriTable.ToList();
            return View(degerler);
        }
    }
}