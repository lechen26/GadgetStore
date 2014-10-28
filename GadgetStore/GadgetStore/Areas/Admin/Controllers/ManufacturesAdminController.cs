using GadgetStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetStore.Areas.Admin.Controllers
{
    public class ManufacturesAdminController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();
        //
        // GET: /Admin/ManufactureAdmin/

        public ActionResult Index()
        {
            var manufactures = storeDB.Manufactures.ToList();

            return View(manufactures);
        }

        //
        // GET: /Admin/ManufactureAdmin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/ManufactureAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ManufactureAdmin/Create

        [HttpPost]
        public ActionResult Create(ManufactureModel Manuf)
        {
            if (ModelState.IsValid)
            {
                storeDB.Manufactures.Add(Manuf);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Manuf);
        }

        //
        // GET: /Admin/ManufactureAdmin/Edit/5
        public ActionResult Edit(int id = 0)
        {
            ManufactureModel Manuf = storeDB.Manufactures.Single(c => c.ManufactureId == id);
            if (Manuf == null)
            {
                return HttpNotFound();
            }
            return View(Manuf);
        }

        //
        // POST: //Admin/ManufactureAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ManufactureId,Name,Description,PhotoUrl")] ManufactureModel Manuf)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(Manuf).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Manuf);
        }

        //
        // GET: /Admin/ManufactureAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ManufactureModel Manuf = storeDB.Manufactures.Single(c => c.ManufactureId == id);
            if (Manuf == null)
                if (Manuf == null)
                {
                    return HttpNotFound();
                }
            return View(Manuf);
        }

        //
        // POST: /Admin/ManufactureAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ManufactureModel Manuf = storeDB.Manufactures.Single(c => c.ManufactureId == id);
            storeDB.Manufactures.Remove(Manuf);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

