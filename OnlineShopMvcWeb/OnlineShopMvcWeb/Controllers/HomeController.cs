﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMvcWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
            ViewBag.CultureName = System.Globalization.CultureInfo.CurrentCulture.Name;
            ViewBag.Today = DateTime.Today.ToLongDateString();

            return View();
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