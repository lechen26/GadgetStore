﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using GadgetStore.Models;
<<<<<<< HEAD
=======
using WebMatrix.WebData;
>>>>>>> origin/chen

namespace GadgetStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start()
<<<<<<< HEAD
        {            
=======
        {
            Database.SetInitializer<GadgetEntities>(new SampleData());
            GadgetEntities context = new GadgetEntities();
            context.Database.Initialize(true);
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("GadgetEntities",
                     "UserProfile", "UserId", "UserName", autoCreateTables: true);
>>>>>>> origin/chen
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
<<<<<<< HEAD
            AuthConfig.RegisterAuth();
            Database.SetInitializer(new SampleData());
=======
            AuthConfig.RegisterAuth();                        
            
>>>>>>> origin/chen
        }
    }
}