﻿using GadgetStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult Create(ItemModel item)
        {
            if (ModelState.IsValid)
            {
                storeDB.Items.Add(item);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Admin/ItemsAdmin/Edit/5
        public ActionResult Edit(int id = 0)
        {
            ItemModel item = storeDB.Items.Single(c => c.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: //Admin/ItemsAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ItemId,Name,Description,PhotoUrl")] ItemModel item)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(item).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Admin/ItemsAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ItemModel item = storeDB.Items.Single(c => c.ItemId == id);
            if (item == null)                
                if (item == null)
                {
                    return HttpNotFound();
                }
            return View(item);
        }

        //
        // POST: /Admin/ItemsAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModel item = storeDB.Items.Single(c => c.ItemId == id);
            storeDB.Items.Remove(item);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

