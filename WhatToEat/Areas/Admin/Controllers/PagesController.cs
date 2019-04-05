﻿using System;
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
        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }
        //Post: Admin/Pages/AddPage
        [HttpPost]
        public ActionResult AddPage(PageVM model)
        {
            // Check model state

            if (!ModelState.IsValid)

            {
                return View(model);
            }

            using (Db db = new Db())
            {
                // Declare slug
                string slug;

                // Init pageDTO
                PageDTO dto = new PageDTO();

                // DTO Title
                dto.Title = model.Title;
                //Check for and set slug if need be
                if (string.IsNullOrWhiteSpace(model.Slug))
                {
                    slug = model.Title.Replace(" ", " ").ToLower();
                }
                else
                {
                    slug = model.Slug.Replace(" ", " ").ToLower();
                }
                // Makesure title and slug are unique 
                if (db.Pages.Any(x => x.Title == model.Title) || db.Pages.Any(x => x.Slug == slug))

                {
                    ModelState.AddModelError("", "That Title or Slug already exists.");
                    return View(model);
                }

                // DTO rest
                dto.Slug = slug;
                dto.Body = model.Body;
                dto.HasSidebar = model.HasSidebar;
                dto.Sorting = 100;

                // Save DTO
                db.Pages.Add(dto);
                db.SaveChanges();

            }

            // Set TempData message
            TempData["SM"] = "You have added a new page!";

            // Redirect
            return RedirectToAction("AddPage");

        }
        //Get: Admin/Pages/EditPage/id
        [HttpGet]
        public ActionResult EditPage(int id)


        {

            //Declare pageVM
            PageVM model;

            using (Db db = new Db())
            {

                // Get the page
                PageDTO dto = db.Pages.Find(id);
                // confirm page exists
                if (dto == null)

                {
                    return Content("The Page Does Not Exist");
                }

                // Init pageVM
                model = new PageVM(dto);

            }


            // Return view with model 

            return View(model);
        }
        //Get: Admin/Pages/EditPage/id
        [HttpPost]
        public ActionResult EditPage(PageVM model)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())

            {
                // Get page ID
                int id = model.Id;
                // Init slug
                string slug = "Home";

                // Get the page
                PageDTO dto = db.Pages.Find(id);

                //DTO title
                dto.Title = model.Title;

                // Check for slug and set in need be
                if (model.Slug != "Home")
                {
                    if (string.IsNullOrWhiteSpace(model.Slug))
                    {
                        slug = model.Title.Replace(" ", " ").ToLower();
                    }
                    else
                    {
                        slug = model.Title.Replace(" ", " ").ToLower();
                    }

                }

                // Make sure title and slug are unique
                if (db.Pages.Where(X => X.Id != id).Any(x => x.Title == model.Title) ||
                   db.Pages.Where(X => X.Id != id).Any(x => x.Slug == slug))

                    // DTO the rest
                    dto.Slug = slug;
                dto.Body = model.Body;
                dto.HasSidebar = model.HasSidebar;

                // Save the DTO
                db.SaveChanges();
            }

            // Set TempData message
            TempData["sm"] = "You have edited the page!";

            // Redirect 
            return RedirectToAction("EditPage");

        }
        //Get: Admin/Pages/PageDetails/id
        public ActionResult PageDetails(int id)
        {
            // Declare PageVM
            PageVM model;

            using (Db db = new Db())
            {
                //Get the page
                PageDTO dto = db.Pages.Find(id);

                // Confirm page exists
                if (dto == null)
                {
                    return Content("The page does not exist.");
                }

                // Init PageVM
                model = new PageVM(dto);
                return View(model);
            }

        }
    }

}