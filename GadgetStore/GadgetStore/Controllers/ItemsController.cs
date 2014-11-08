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

        public ActionResult Index(string searchString, string category, string manufacture, string price)
        {   
            var pri=0M;      
            if (!String.IsNullOrEmpty(price))
                pri = Decimal.Parse(price);

            //Generic List of Items
            var items = from i in storeDB.Items
                        where (decimal)i.Price > pri
                        select i;

            //Select Items according to Search String
            if (!String.IsNullOrEmpty(searchString))
            {
                items = from i in storeDB.Items
                        where i.Name.Contains(searchString) && (decimal)i.Price > pri
                            select i;
            }

            //Search Items according to Category (and searchString if applied)
            if (!String.IsNullOrEmpty(category))
            {
                items = from i in storeDB.Items
                        join c in storeDB.Categories on i.CategoryId equals c.CategoryId
                        where i.Name.Contains(searchString) && c.Name.Contains(category) && i.Price > pri
                        select i;
            }

            //Search Items according to Manufacture (and searchString if applied)
            if (!String.IsNullOrEmpty(manufacture))
            {
                items = from i in storeDB.Items
                        join m in storeDB.Manufactures on i.ManufactureId equals m.ManufactureId
                        where i.Name.Contains(searchString) && m.Name.Contains(manufacture) && i.Price > pri
                        select i;
            }
          
            //Search Items according to Manufacture and Category (and searchString if applied)
            if (!String.IsNullOrEmpty(manufacture))
            {
                items = from i in storeDB.Items
                        join m in storeDB.Manufactures on i.ManufactureId equals m.ManufactureId
                        join c in storeDB.Categories on i.CategoryId equals c.CategoryId
                        where i.Name.Contains(searchString) && m.Name.Contains(manufacture) && c.Name.Contains(category) && i.Price > pri
                        select i;
            }         
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

            ViewBag.SpecificOrdersAmmount = GetSpecificOrdersAmount(id);

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

        private List<ItemModel> GetTopSellingItem(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Items
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();



        }

        private int GetSpecificOrdersAmount(int ItemIdent)
        {
            // Get the number of Order amount of specific product
            var query = from c in storeDB.Items
                        where c.ItemId.Equals(ItemIdent)
                        select c.OrderDetails.Count();
            var count = (int)query.First();

            return count;                                              
        }

        private List<ItemChart> ItemOrdersChart()
        {
            //Get the number of orders for each item.
            var query = from i in storeDB.Items
                        select new ItemChart() { Id = i.ItemId, Name = i.Name, Count = i.OrderDetails.Count };
                        
                        
            return query.ToList();

        }

        public ActionResult ItemsChart()
        {
            ViewData["ChartInfo"] = ItemOrdersChart();
            return PartialView("ItemsChart");
        }

       
    }

}
