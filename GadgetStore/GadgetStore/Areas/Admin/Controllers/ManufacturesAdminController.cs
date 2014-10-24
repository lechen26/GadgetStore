using GadgetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetStore.Areas.Admin.Controllers
{
    public class ManufacturesAdminController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();

        //
        // GET: /ManufacturesAdmin/

        public ActionResult Index()
        {
            var manufactures = storeDB.Manufactures.ToList();
            return View(manufactures);
        }

        //
        // GET: /Admin/ManufacturesAdmin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/ManufacturesAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ManufacturesAdmin/Create

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
        // GET: /Admin/ManufacturesAdmin/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ManufacturesAdmin/Edit/5

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
        // GET: /Admin/ManufacturesAdmin/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ManufacturesAdmin/Delete/5

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
