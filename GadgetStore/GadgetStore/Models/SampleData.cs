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
            const string ImgItemsUrl = "~/Content/Images/Items/";
            var manufactures = AddManufactures(context, ImgManufactureUrl);
            var categories = AddCategories(context, ImgCategoryUrl);
            context.SaveChanges();
            AddItems(context, ImgUrl, manufactures, categories, ImgItemsUrl);
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
                new CategoryModel { Name = "Cellular",Description="Cellular", PhotoUrl = CategoryImgDir + "Cellular.png" },
                new CategoryModel { Name = "PcParts",Description="PcParts", PhotoUrl = CategoryImgDir + "PcParts.png" },
                new CategoryModel { Name = "Tablets",Description="Tablets", PhotoUrl = CategoryImgDir + "Tablets.png" },
                new CategoryModel { Name = "Laptops",Description="Laptops", PhotoUrl = CategoryImgDir + "Laptops.png" },
                new CategoryModel { Name = "Gadgets",Description="Gadgets", PhotoUrl = CategoryImgDir + "Gadgets.png" },
                new CategoryModel { Name = "Accessories",Description="Accessories", PhotoUrl = CategoryImgDir + "Accessories.png" }, 
                new CategoryModel { Name = "Coupons",Description="Coupons", PhotoUrl = CategoryImgDir + "Coupons.png" }
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
            return categories;
        }


        private static void AddItems(GadgetEntities context, string imgUrl, List<ManufactureModel> manufactures, List<CategoryModel> categories, string imgItemUr)
        {
            context.Items.Add(new ItemModel { Name = "iPhone 4S 16G", Description = "iPhone 4S 16G", PhotoUrl = imgItemUr + "1.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 99 });
            context.Items.Add(new ItemModel { Name = "iPhone 4S 32G", Description = "iPhone 4S 32G", PhotoUrl = imgItemUr + "1.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 99 });
            context.Items.Add(new ItemModel { Name = "iPhone 5 16G", Description = "iPhone 5 16G", PhotoUrl = imgItemUr + "2.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 199});
            context.Items.Add(new ItemModel { Name = "iPhone 5 32G", Description = "iPhone 5 32G", PhotoUrl = imgItemUr + "2.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 199 });
            context.Items.Add(new ItemModel { Name = "iPhone 5S 16G", Description = "iPhone 5S 16G", PhotoUrl = imgItemUr + "3.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 249 });
            context.Items.Add(new ItemModel { Name = "iPhone 5S 32G", Description = "iPhone 5S 32G", PhotoUrl = imgItemUr + "3.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 249 });
            context.Items.Add(new ItemModel { Name = "Nexus 5 16G", Description = "Nexus 5 16G", PhotoUrl = imgItemUr + "4.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "LG"), Price = 299 });
            context.Items.Add(new ItemModel { Name = "Nexus 5 32G", Description = "Nexus 5 32G", PhotoUrl = imgItemUr + "4.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "LG"), Price = 349 });
            context.Items.Add(new ItemModel { Name = "Galaxy S3 16G", Description = "Galaxy S3 16G", PhotoUrl = imgItemUr + "5.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 99 });
            context.Items.Add(new ItemModel { Name = "Galaxy S3 32G", Description = "Galaxy S3 32G", PhotoUrl = imgItemUr + "5.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 199 });
            context.Items.Add(new ItemModel { Name = "Galaxy S4 16G", Description = "Galaxy S4 16G", PhotoUrl = imgItemUr + "6.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 199 });
            context.Items.Add(new ItemModel { Name = "Galaxy S4 32G", Description = "Galaxy S4 32G", PhotoUrl = imgItemUr + "6.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 249 });
            context.Items.Add(new ItemModel { Name = "Galaxy S5 16G", Description = "Galaxy S5 16G", PhotoUrl = imgItemUr + "7.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 299 });
            context.Items.Add(new ItemModel { Name = "Galaxy S5 32G", Description = "Galaxy S5 32G", PhotoUrl = imgItemUr + "7.png", CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 349 });
            context.Items.Add(new ItemModel { Name = "iPad Mini 16G", Description = "iPad Mini 16G", PhotoUrl = imgItemUr + "8.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 499 });
            context.Items.Add(new ItemModel { Name = "iPad Mini 32G", Description = "iPad Mini 32G", PhotoUrl = imgItemUr + "8.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 599 });
            context.Items.Add(new ItemModel { Name = "iPad Air 16G", Description = "iPad Air 16G", PhotoUrl = imgItemUr + "9.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 599 });
            context.Items.Add(new ItemModel { Name = "iPad Air 32G", Description = "iPad Air 32G", PhotoUrl = imgItemUr + "9.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699 });
            context.Items.Add(new ItemModel { Name = "iPad 16G", Description = "iPad 16G", PhotoUrl = imgItemUr + "10.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699 });
            context.Items.Add(new ItemModel { Name = "iPad 32G", Description = "iPad 32G", PhotoUrl = imgItemUr + "10.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 799 });
            context.Items.Add(new ItemModel { Name = "GalaxyTab 16G", Description = "GalaxyTab 16G", PhotoUrl = imgItemUr + "11.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 299 });
            context.Items.Add(new ItemModel { Name = "GalaxyTab 32G", Description = "GalaxyTab 32G", PhotoUrl = imgItemUr + "11.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 399 });
            context.Items.Add(new ItemModel { Name = "Nexus 10 16G", Description = "Nexus 10 16G", PhotoUrl = imgItemUr + "12.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Google"), Price = 399 });
            context.Items.Add(new ItemModel { Name = "Nexus 10 32G", Description = "Nexus 10 32G", PhotoUrl = imgItemUr + "12.png", CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Google"), Price = 499 });
            context.Items.Add(new ItemModel { Name = "MacBook Air 11\"", Description = "MacBook Air 11", PhotoUrl = imgItemUr + "13.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699 });
            context.Items.Add(new ItemModel { Name = "MacBook Air 13\"", Description = "MacBook Air 13", PhotoUrl = imgItemUr + "13.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 799 });
            context.Items.Add(new ItemModel { Name = "MacBook Pro 13\"", Description = "MacBook Pro 13", PhotoUrl = imgItemUr + "13.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 899 });
            context.Items.Add(new ItemModel { Name = "MacBook Pro 15\"", Description = "MacBook Pro 15", PhotoUrl = imgItemUr + "13.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 999 });
            context.Items.Add(new ItemModel { Name = "Zbook 15\"", Description = "Zbook 15", PhotoUrl = imgItemUr + "14.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "HP"), Price = 899 });
            context.Items.Add(new ItemModel { Name = "Zbook 17\"", Description = "Zbook 17", PhotoUrl = imgItemUr + "14.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "HP"), Price = 999 });
            context.Items.Add(new ItemModel { Name = "ZenBook 13\"", Description = "ZenBook 13", PhotoUrl = imgItemUr + "14.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Asus"), Price = 1099 });
            context.Items.Add(new ItemModel { Name = "ZenBook 15\"", Description = "ZenBook 15", PhotoUrl = imgItemUr + "14.png", CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Asus"), Price = 1199 });
            context.Items.Add(new ItemModel { Name = "Beats In-Ear", Description = "Beats Headphones ", PhotoUrl = imgItemUr + "15.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 299 });
            context.Items.Add(new ItemModel { Name = "Beats On-Ear", Description = "Beats Headphones ", PhotoUrl = imgItemUr + "16.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 299 });
            context.Items.Add(new ItemModel { Name = "G430 Headphones", Description = "G430 Headphones ", PhotoUrl = imgItemUr + "17.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 199 });
            context.Items.Add(new ItemModel { Name = "Wireless Keyboard", Description = "Wireless Keyboard", PhotoUrl = imgItemUr + "18.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 99 });
            context.Items.Add(new ItemModel { Name = "Wireless Mouse", Description = "Wireless Mouse", PhotoUrl = imgItemUr + "19.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 99 });
            context.Items.Add(new ItemModel { Name = "K260", Description = "K260 Keyboard and Mouse", PhotoUrl = imgItemUr + "20.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 199 });
            context.Items.Add(new ItemModel { Name = "G402 Mouse", Description = "G402 Mouse wireless", PhotoUrl = imgItemUr + "21.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 49 });
            context.Items.Add(new ItemModel { Name = "Speakers Z213", Description = "Multimedia Speakers Z213", PhotoUrl = imgItemUr + "22.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 349 });
            context.Items.Add(new ItemModel { Name = "Speakers Z50", Description = "Multimedia Speakers Z50", PhotoUrl = imgItemUr + "23.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 349 });
            context.Items.Add(new ItemModel { Name = "Case Galaxy S3", Description = "PutGear Sillicon Case GalaxyS3", PhotoUrl = imgItemUr + "24.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 49 });
            context.Items.Add(new ItemModel { Name = "Case iPhone 5", Description = "IFace Mall Case iPhone 5", PhotoUrl = imgItemUr + "25.png", CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 49 });
        }
    }
}
