using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatToEat.Areas.Admin.Controllers
{
    public class EateryController : Controller
    {
        // GET: Admin/Eatery
        public ActionResult Index()
        {
            return View();
        }
    }
}