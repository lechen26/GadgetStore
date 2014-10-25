﻿using GadgetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetStore.Areas.Admin.Controllers
{
    public class CategoriesAdminController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();
        //
        // GET: /Admin/CategoriesAdmin/

        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();

            return View(categories);
        }

        //
        // GET: /Admin/CategoriesAdmin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/CategoriesAdmin/Create

        public ActionResult Create()
        {            
            return View();
        }

        //
        // POST: /Admin/CategoriesAdmin/Create

        [HttpPost]
        public ActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                storeDB.Categories.Add(category);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(category);
        }

        //
        // GET: /Admin/CategoriesAdmin/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/CategoriesAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/CategoriesAdmin/Delete/5

        public ActionResult Delete(int id=0)
        {
            CategoryModel cat = storeDB.Categories.Find(id);            
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        //
        // POST: /Admin/CategoriesAdmin/Delete/5
         [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryModel cat = storeDB.Categories.Find(id);
            storeDB.Categories.Remove(cat);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}