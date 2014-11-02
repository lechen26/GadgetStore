using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using System.Data.Entity;
using System.Web.Security;



namespace GadgetStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<GadgetEntities>
    {
        protected override void Seed(GadgetEntities context)
        {
            WebSecurity.InitializeDatabaseConnection("GadgetEntities", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            AddRolesAndUser();
            const string ImgUrl = "~/Content/Images/placeholder.png";
            const string ImgCategoryUrl = "~/Content/Images/Categories/";
            const string ImgManufactureUrl = "~/Content/Images/Manufactures/";            
            var manufactures = AddManufactures(context, ImgManufactureUrl);
            var categories = AddCategories(context, ImgCategoryUrl);
            context.SaveChanges();
            AddItems(context, ImgUrl, manufactures, categories);
            context.SaveChanges();
        }


        private static void AddRolesAndUser()
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;
            if (!roles.RoleExists("Admin"))
                roles.CreateRole("Admin");
            if (!roles.RoleExists("User"))
                roles.CreateRole("User");
            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "Password1!");
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
            }
        }

        private static List<ManufactureModel> AddManufactures(GadgetEntities context, string ImgUrlManu)
        {
            var manufactures = new List<ManufactureModel>
             {
                new ManufactureModel { Name = "Apple",Description="Apple Manufacture", PhotoUrl = ImgUrlManu + "apple.png" },                
                new ManufactureModel { Name = "Samsung",Description="Samsung Manufacture", PhotoUrl = ImgUrlManu + "samsung.png" },
                new ManufactureModel { Name = "Google",Description="Google Manufacture", PhotoUrl = ImgUrlManu + "google.png" },
                new ManufactureModel { Name = "LG",Description="LG Manufacture", PhotoUrl = ImgUrlManu + "lg.png" },
                new ManufactureModel { Name = "HP",Description="HP Manufacture", PhotoUrl = ImgUrlManu + "hp.png" },
                new ManufactureModel { Name = "Dell",Description="Dell Manufacture", PhotoUrl = ImgUrlManu + "dell.png" },
                new ManufactureModel { Name = "Asus",Description="Asus Manufacture", PhotoUrl = ImgUrlManu + "asus.png" },
                new ManufactureModel { Name = "Logitech",Description="Logitech Manufacture", PhotoUrl = ImgUrlManu + "logitech.png" }                

             };
            manufactures.ForEach(s => context.Manufactures.Add(s));
            context.SaveChanges();
            return manufactures;
        }


        private static List<CategoryModel> AddCategories(GadgetEntities context, string CategoryImgDir)
        {
            var categories = new List<CategoryModel> 
             {
                new CategoryModel { Name = "Cellular",Description="Cellular devices", PhotoUrl = CategoryImgDir + "Cellular.png" },
                new CategoryModel { Name = "PcParts",Description="PcParts", PhotoUrl = CategoryImgDir + "Cellular.png" },
                new CategoryModel { Name = "Tablets",Description="Tablets", PhotoUrl = CategoryImgDir + "Tablets.png" },
                new CategoryModel { Name = "Laptops",Description="Laptops", PhotoUrl = CategoryImgDir + "Laptops.png" },
                new CategoryModel { Name = "Gadgets",Description="Cool Gadgets", PhotoUrl = CategoryImgDir + "Gadgets.png" },
                new CategoryModel { Name = "Accessories",Description="Cellular ", PhotoUrl = CategoryImgDir + "Accessories.png" }, 
                new CategoryModel { Name = "Coupons",Description="Coupons", PhotoUrl = CategoryImgDir + "Coupons.png" }
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
            return categories;
        }


        private static void AddItems(GadgetEntities context, string imgUrl, List<ManufactureModel> manufactures, List<CategoryModel> categories)
        {
            context.Items.Add(new ItemModel { Name = "Iphone4s 16", Description = "Iphone 4s 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 99});
            context.Items.Add(new ItemModel { Name = "Iphone4s 32", Description = "Iphone 4s 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 99});
            context.Items.Add(new ItemModel { Name = "Iphone5 16", Description = "Iphone 5 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 199});
            context.Items.Add(new ItemModel { Name = "Iphone5 32", Description = "Iphone 5 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 199});
            context.Items.Add(new ItemModel { Name = "Iphone5s 16", Description = "Iphone 5s 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 249});
            context.Items.Add(new ItemModel { Name = "Iphone5s 32", Description = "Iphone 5s 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 249});
            context.Items.Add(new ItemModel { Name = "Nexus5 16", Description = "Nexus 5 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "LG"), Price = 299});
            context.Items.Add(new ItemModel { Name = "Nexus5 32", Description = "Nexus 5 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "LG"), Price = 349});
            context.Items.Add(new ItemModel { Name = "GalaxyS3 16", Description = "GalaxyS3 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 99});
            context.Items.Add(new ItemModel { Name = "GalaxyS3 32", Description = "GalaxyS3 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 199});
            context.Items.Add(new ItemModel { Name = "GalaxyS4 16", Description = "GalaxyS4 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 199});
            context.Items.Add(new ItemModel { Name = "GalaxyS4 32", Description = "GalaxyS4 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 249});
            context.Items.Add(new ItemModel { Name = "GalaxyS5 16", Description = "GalaxyS5 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 299});
            context.Items.Add(new ItemModel { Name = "GalaxyS5 32", Description = "GalaxyS5 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 349});
            context.Items.Add(new ItemModel { Name = "Ipad mini 16", Description = "Ipad mini 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 499});
            context.Items.Add(new ItemModel { Name = "Ipad mini 32", Description = "Ipad mini 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 599});
            context.Items.Add(new ItemModel { Name = "Ipad Air 16", Description = "Ipad Air 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 599});
            context.Items.Add(new ItemModel { Name = "Ipad Air 32", Description = "Ipad Air 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699});
            context.Items.Add(new ItemModel { Name = "Ipad 16", Description = "Ipad 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699});
            context.Items.Add(new ItemModel { Name = "Ipad 32", Description = "Ipad 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 799});
            context.Items.Add(new ItemModel { Name = "GalaxyTab 16", Description = "GalaxyTab 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 299});
            context.Items.Add(new ItemModel { Name = "GalaxyTab 32", Description = "GalaxyTab 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 399});
            context.Items.Add(new ItemModel { Name = "Nexus10 16", Description = "Nexus10 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Google"), Price = 399});
            context.Items.Add(new ItemModel { Name = "Nexus10 32", Description = "Nexus10 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Google"), Price = 499});
            context.Items.Add(new ItemModel { Name = "MacBookAir 11", Description = "MacBookAir 11", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699});
            context.Items.Add(new ItemModel { Name = "MacBookAir 13", Description = "MacBookAir 13", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 799});
            context.Items.Add(new ItemModel { Name = "MacBookPro 13", Description = "MacBookPro 13", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 899});
            context.Items.Add(new ItemModel { Name = "MacBookPro 15", Description = "MacBookPro 15", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 999});
            context.Items.Add(new ItemModel { Name = "Zbook 15", Description = "Zbook 15", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "HP"), Price = 899});
            context.Items.Add(new ItemModel { Name = "Zbook 17", Description = "Zbook 17", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "HP"), Price = 999});
            context.Items.Add(new ItemModel { Name = "ZenBook 13", Description = "ZenBook 13", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Asus"), Price = 1099});
            context.Items.Add(new ItemModel { Name = "ZenBook 15", Description = "ZenBook 15", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Asus"), Price = 1199});
            context.Items.Add(new ItemModel { Name = "Beats Headphones In-Ear", Description = "Beats Headphones ", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 299});
            context.Items.Add(new ItemModel { Name = "Beats Headphones On-Ear", Description = "Beats Headphones ", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 299});
            context.Items.Add(new ItemModel { Name = "G430 Headphones", Description = "G430 Headphones ", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 199});
            context.Items.Add(new ItemModel { Name = "KeyBoard wireless", Description = "KeyBoard wireless", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 99});
            context.Items.Add(new ItemModel { Name = "Mouse wireless", Description = "Mouse wireless", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 99});
            context.Items.Add(new ItemModel { Name = "K260 KeyBoard and Mouse wireless", Description = "K260 KeyBoard+Mouse wireles", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 199});
            context.Items.Add(new ItemModel { Name = "G402 Mouse wireless", Description = "G402 Mouse wireless", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 49});
            context.Items.Add(new ItemModel { Name = "Multimedia Speakers Z213", Description = "Multimedia Speakers Z213", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 349});
            context.Items.Add(new ItemModel { Name = "Multimedia Speakers Z50", Description = "Multimedia Speakers Z50", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 349});
            context.Items.Add(new ItemModel { Name = "PutGear Sillicon Case GalaxyS3", Description = "PutGear Sillicon Case GalaxyS3", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 49});
            context.Items.Add(new ItemModel { Name = "IFace Mall Case Iphone5", Description = "IFace Mall Case Iphone5", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 49});
        }
    }
}
