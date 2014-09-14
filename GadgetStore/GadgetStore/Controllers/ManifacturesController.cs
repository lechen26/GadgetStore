using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetStore.Models;

namespace GadgetStore.Controllers
{
    public class ManifacturesController : Controller
    {

        GadgetEntities storeDB = new GadgetEntities();

        //
        // GET: /Manifactures/

        public ActionResult Index()
        {
            var manufactures = storeDB.Manufactures.ToList();
            return View(manufactures);    
        }

        //
        // GET: /Manifactures/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Manifactures/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manifactures/Create

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
        // GET: /Manifactures/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manifactures/Edit/5

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
        // GET: /Manifactures/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manifactures/Delete/5

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
