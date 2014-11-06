using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

        public ActionResult Index(string ManuNameSearch)
        {
            var manufactures = from u in storeDB.Manufactures
                         select u;
            if (!String.IsNullOrEmpty(ManuNameSearch))
            {
                manufactures = manufactures.Where(s => s.Name.Contains(ManuNameSearch));
            }          
            return View(manufactures);
        }

        //
        // GET: /Manufactures/Details/5

        public ActionResult Details(int id)
        {
            var manufa = storeDB.Manufactures.Find(id);
            var query =  from c in storeDB.Manufactures
                         where c.ManufactureId.Equals(id)
                         join i in storeDB.Items
                         on c.ManufactureId equals i.ManufactureId
                         select i;
            ViewBag.manufacItems = query.ToList();
            return View(manufa);
        }

        //
        // GET : /Manufactures/
        public ActionResult Browse(string manufacture)
        {
            var query = from c in storeDB.Manufactures
                        where c.Name.Equals(manufacture)
                        join i in storeDB.Items
                        on c.ManufactureId equals i.ManufactureId
                        select i;

            return View(query.ToList()); 
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



        private List<ItemChart> ManufacturesItemsChart()
        {
            //Get the number of products per manufacture
            var query = from i in storeDB.Items
                        join m in storeDB.Manufactures on i.ManufactureId equals m.ManufactureId
                        group m by new { m.ManufactureId, m.Name } into g
                        select new ItemChart() { Id = g.Key.ManufactureId, Name = g.Key.Name, Count = g.Count() };


            return query.ToList();

        }


  



        public ActionResult ManufChart()
        {
            ViewData["ChartInfo"] = ManufacturesItemsChart();
            return PartialView("ManufChart");
        }
    }
}