using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatToEat.Models.Data;
using WhatToEat.Models.ViewModels.Eatery;

namespace WhatToEat.Controllers
{
    public class EateryController : Controller
    {
        // GET: Eatery
        public ActionResult Index()
        
        {
           return RedirectToAction("Index", "Pages");
        }

        public ActionResult CategoryMenuPartial()
        {
            //Declare list of CategoryVM
            List<CategoryVM> categoryVMList;

            //Init the list
            using (Db db = new Db())
            {
                categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }

            //Return partial with list
            return PartialView(categoryVMList);
        }
    }
}