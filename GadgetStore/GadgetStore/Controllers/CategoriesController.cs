using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetStore.Models;
using System.Dynamic;

namespace GadgetStore.Controllers
{
    public class CategoriesController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();
        //
        
        // GET: /Categories
        public ActionResult Index(string searchString)
        {
            var categories = from c in storeDB.Categories
                             select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Name.Contains(searchString));
            }
            return View(categories);
        }
       
        public ActionResult ViewPhoto(int id)
        {
            var photo = storeDB.Categories.Find(id).PhotoUrl;
            return File(photo, "image/jpeg"); // you'll need to specify the content type based on your picture
        }
        //
        // GET: /Categories/Details/5

        public ActionResult Details(int id)
        {
            var query = from c in storeDB.Categories
                        where c.CategoryId.Equals(id)
                        join i in storeDB.Items
                        on c.CategoryId equals i.CategoryId
                        select i;
            ViewBag.CategoriesItems = query.ToList();
            var category = storeDB.Categories.Find(id);
            return View(category);
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Categories/Edit/5

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
        // GET: /Categories/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
