using GadgetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetStore.Areas.Admin.Controllers
{
    public class ItemsAdminController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();
        //
        // GET: /Admin/ItemsAdmin/

        public ActionResult Index()
        {
            var items = storeDB.Items.ToList();
            return View(items);       
        }

        //
        // GET: /Admin/ItemsAdmin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/ItemsAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ItemsAdmin/Create

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
        // GET: /Admin/ItemsAdmin/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ItemsAdmin/Edit/5

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
        // GET: /Admin/ItemsAdmin/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ItemsAdmin/Delete/5

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
