using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GadgetStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<GadgetEntities>
    {
        protected override void Seed(GadgetEntities context)
        {
            const string ImgUrl = "~/Content/Images/placeholder.png";
            var manufactures = AddManufactures(context, ImgUrl);
            var categories = AddCategories(context, ImgUrl);
            context.SaveChanges();
            AddItems(context, ImgUrl, manufactures, categories);
            context.SaveChanges();
        }

        private static List<ManufactureModel> AddManufactures(GadgetEntities context, string imgUrl)
         {
             var manufactures  = new List<ManufactureModel>
             {
                new ManufactureModel { Name = "Apple",Decription="Apple Manufacture", PhotoUrl = imgUrl },                
                new ManufactureModel { Name = "Samsung",Decription="Samsung Manufacture", PhotoUrl = imgUrl },
                new ManufactureModel { Name = "Google",Decription="Google Manufacture", PhotoUrl = imgUrl },
                new ManufactureModel { Name = "LG",Decription="LG Manufacture", PhotoUrl = imgUrl },
                new ManufactureModel { Name = "HP",Decription="HP Manufacture", PhotoUrl = imgUrl },
                new ManufactureModel { Name = "Dell",Decription="Dell Manufacture", PhotoUrl = imgUrl },
                new ManufactureModel { Name = "Asus",Decription="Asus Manufacture", PhotoUrl = imgUrl },
                new ManufactureModel { Name = "Logitech",Decription="Logitech Manufacture", PhotoUrl = imgUrl }                

             };
             manufactures.ForEach(s=> context.Manufactures.Add(s));
             context.SaveChanges();
             return manufactures;
         }


        private static List<CategoryModel> AddCategories(GadgetEntities context, string imgUrl)
        {
            var categories = new List<CategoryModel> 
             {
                new CategoryModel { Name = "Cellular",Decription="Cellular devices", PhotoUrl = imgUrl },
                new CategoryModel { Name = "Tablets",Decription="Tablets", PhotoUrl = imgUrl },
                new CategoryModel { Name = "Laptops",Decription="Laptops", PhotoUrl = imgUrl },
                new CategoryModel { Name = "Gadgets",Decription="Cool Gadgets", PhotoUrl = imgUrl },
                new CategoryModel { Name = "Accessories",Decription="Cellular Accessories", PhotoUrl = imgUrl }, 
                new CategoryModel { Name = "Coupons",Decription="Coupons", PhotoUrl = imgUrl }
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
            return categories;
        }


        private static void AddItems(GadgetEntities context, string imgUrl, List<ManufactureModel> manufactures, List<CategoryModel> categories)
        {
            context.Items.Add(new ItemModel { Name = "Iphone4s 16", Decription = "Iphone 4s 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 99, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Iphone4s 32", Decription = "Iphone 4s 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 99, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Iphone5 16", Decription = "Iphone 5 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Iphone5 32", Decription = "Iphone 5 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Iphone5s 16", Decription = "Iphone 5s 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 249, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Iphone5s 32", Decription = "Iphone 5s 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 249, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Nexus5 16", Decription = "Nexus 5 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "LG"), Price = 299, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Nexus5 32", Decription = "Nexus 5 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "LG"), Price = 349, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyS3 16", Decription = "GalaxyS3 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 99, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyS3 32", Decription = "GalaxyS3 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyS4 16", Decription = "GalaxyS4 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyS4 32", Decription = "GalaxyS4 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 249, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyS5 16", Decription = "GalaxyS5 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 299, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyS5 32", Decription = "GalaxyS5 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Cellular"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 349, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Ipad mini 16", Decription = "Ipad mini 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 499, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Ipad mini 32", Decription = "Ipad mini 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 599, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Ipad Air 16", Decription = "Ipad Air 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 599, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Ipad Air 32", Decription = "Ipad Air 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Ipad 16", Decription = "Ipad 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Ipad 32", Decription = "Ipad 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 799, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyTab 16", Decription = "GalaxyTab 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 299, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "GalaxyTab 32", Decription = "GalaxyTab 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 399, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Nexus10 16", Decription = "Nexus10 16G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Google"), Price = 399, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Nexus10 32", Decription = "Nexus10 32G", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Tablets"), ManufactureModel = manufactures.Single(a => a.Name == "Google"), Price = 499, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "MacBookAir 11", Decription = "MacBookAir 11", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 699, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "MacBookAir 13", Decription = "MacBookAir 13", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 799, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "MacBookPro 13", Decription = "MacBookPro 13", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 899, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "MacBookPro 15", Decription = "MacBookPro 15", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 999, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Zbook 15", Decription = "Zbook 15", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "HP"), Price = 899, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Zbook 17", Decription = "Zbook 17", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "HP"), Price = 999, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "ZenBook 13", Decription = "ZenBook 13", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Asus"), Price = 1099, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "ZenBook 15", Decription = "ZenBook 15", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Laptops"), ManufactureModel = manufactures.Single(a => a.Name == "Asus"), Price = 1199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Beats Headphones In-Ear", Decription = "Beats Headphones ", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 299, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Beats Headphones On-Ear", Decription = "Beats Headphones ", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 299, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "G430 Headphones", Decription = "G430 Headphones ", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "KeyBoard wireless", Decription = "KeyBoard wireless", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 99, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Mouse wireless", Decription = "Mouse wireless", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 99, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "K260 KeyBoard and Mouse wireless", Decription = "K260 KeyBoard+Mouse wireles", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 199, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "G402 Mouse wireless", Decription = "G402 Mouse wireless", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 49, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Multimedia Speakers Z213", Decription = "Multimedia Speakers Z213", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 349, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "Multimedia Speakers Z50", Decription = "Multimedia Speakers Z50", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Logitech"), Price = 349, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "PutGear Sillicon Case GalaxyS3", Decription = "PutGear Sillicon Case GalaxyS3", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Samsung"), Price = 49, PurchaseAmount = 0, AddedAt = DateTime.Now });
            context.Items.Add(new ItemModel { Name = "IFace Mall Case Iphone5", Decription = "IFace Mall Case Iphone5", PhotoUrl = imgUrl, CategoryModel = categories.Single(a => a.Name == "Accessories"), ManufactureModel = manufactures.Single(a => a.Name == "Apple"), Price = 49, PurchaseAmount = 0, AddedAt = DateTime.Now });
        }
    }
}
