using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetStore.Models;

namespace GadgetStore.Controllers
{
    public class ManufacturesController : Controller
    {

        GadgetEntities storeDB = new GadgetEntities();

        //
        // GET: /Manufactures/

        public ActionResult Index()
        {
            var manufactures = storeDB.Manufactures.ToList();
            return View(manufactures);    
        }

        //
        // GET: /Manufactures/Details/5

        public ActionResult Details(int id)
        {
            var manufa = storeDB.Manufactures.Find(id);
            return View(manufa);
        }

        //
        // GET: /Manufactures/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manufactures/Create

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
        // GET: /Manufactures/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Manufactures/Edit/5

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
        // GET: /Manufactures/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manufactures/Delete/5

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
