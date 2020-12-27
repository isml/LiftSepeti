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
    public class bayianasayfaController : Controller
    {
        // GET: bayianasayfa
        public ActionResult Index(int bayiid)
        {
            LiftSepetiEntities2 db = new LiftSepetiEntities2();

            ViewBag.bayiid = bayiid;
            bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
            ViewBag.bayibilgiler = bayi;
            var liftTable = db.liftTable.Include(l => l.modelTable);
            return View(liftTable.ToList());
        
        }
    }
}