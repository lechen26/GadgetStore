﻿using System.Data.Entity;

namespace GadgetStore.Models
{
    public class GadgetEntities : DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ManufactureModel> Manufactures { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().ToTable("Categories");
            modelBuilder.Entity<ManufactureModel>().ToTable("Manufactures");
            modelBuilder.Entity<ItemModel>().ToTable("Items");            

            base.OnModelCreating(modelBuilder);        
        }
    }
}