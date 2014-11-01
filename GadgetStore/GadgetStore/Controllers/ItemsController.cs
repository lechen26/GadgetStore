using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetStore.Models;

namespace GadgetStore.Controllers
{
    public class ItemsController : Controller
    {

        GadgetEntities storeDB = new GadgetEntities();

        //
        // GET: /Items/

        public ActionResult Index()
        {
            var items = storeDB.Items.ToList();
            return View(items);            
        }

        public ActionResult Browse(string category)
        {
            var query = from c in storeDB.Categories
                        where c.Name.Equals(category)
                        join i in storeDB.Items
                        on c.CategoryId equals i.CategoryId
                        select i;
            return View(query.ToList());
        }

        //
        // GET: /Items/Details/5
        //Details page of an item
        public ActionResult Details(int id)
        {
            //Get the specific item by id.
            var item = storeDB.Items.Find(id);

            // Perform a query in order to get the Manufacture name of the item, to display it on Details page.
            var query = from c in storeDB.Manufactures
                              where c.ManufactureId.Equals(item.ManufactureId)
                              select c.Name;

            //Save the Manufacture name in a ViewBag.
            ViewBag.ManufuctureID = query.First();

            //Perform a query in order to get the Cateory Name for the item, to use it on the Details Page
            var queryCategory = from c in storeDB.Categories
                                where c.CategoryId.Equals(item.CategoryId)
                                select c.Name;

            //Save the Category name in a ViewBag
            ViewBag.Category = queryCategory.First();

            return View(item); 
        }

        //
        // GET: /Items/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Items/Create

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
        // GET: /Items/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Items/Edit/5

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
        // GET: /Items/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Items/Delete/5

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
