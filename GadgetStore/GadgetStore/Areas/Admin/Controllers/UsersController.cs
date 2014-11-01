using GadgetStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetStore.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();

        //
        // GET: /Admin/Users/

        public ActionResult Index(string searchString)
        {
            var users = from u in storeDB.UserProfile
                             select u;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FirstName.Contains(searchString));
            }          
            return View(users);
        }


        //
        // GET: /Admin/Users/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Users/Create

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
        // GET: /Admin/Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile user = storeDB.UserProfile.Single(c => c.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: //Admin/Users/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserId,UserName,FirstName,LastName,Country,City,Address,EmailAddress")] UserProfile user)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(user).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Admin/Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile user = storeDB.UserProfile.Single(c => c.UserId == id);
            if (user == null)
                //CategoryModel cat = storeDB.Categories.Find(id);            
                if (user == null)
                {
                    return HttpNotFound();
                }
            return View(user);
        }

        //
        // POST: /Admin/CategoriesAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile user = storeDB.UserProfile.Single(c => c.UserId == id);
            storeDB.UserProfile.Remove(user);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
