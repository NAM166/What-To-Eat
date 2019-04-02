using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatToEat.Models.Data;
using WhatToEat.Models.ViewModels.Pages;

namespace WhatToEat.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            // Declare list of VM
            List<PageVM> pagesList;

            using (Db db = new Db())
            {
                // Initiate the List
                pagesList = db.Pages.ToArray().OrderBy(x => x.Sorting).Select(x => new PageVM(x)).ToList();

            }
              // Return view with List
              return View(pagesList);
        }
              //Get: Admin/Pages/AddPage
              public ActionResult AddPage()
        {
              return View();
        }
    }
}