using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatToEat.Models.Data;
using WhatToEat.Models.ViewModels.Eatery;

namespace WhatToEat.Areas.Admin.Controllers
{
    public class EateryController : Controller
    {
        // GET: Admin/Eatery/categories
        public ActionResult categories()
        {
            // Declare a list of models
            List<CategoryVM> categoryVMList;

            using (Db db = new Db())
            {
                // Init the list
                categoryVMList = db.Categories
                .ToArray()
                .OrderBy(x => x.Sorting)
                .Select(x => new CategoryVM(x))
                .ToList();
            }

            // Return view to list
            return View(categoryVMList);
        }
    }
}