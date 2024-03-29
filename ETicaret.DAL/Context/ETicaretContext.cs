﻿using ETicaret.DAL.Migrations;
using ETicaret.Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ETicaret.DAL.Context
{
    public class ETicaretContext : IdentityDbContext
    {
        public ETicaretContext() : base("SerTeknoConnstr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ETicaretContext, Configuration>("SerTeknoConnstr"));
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductEvaluation> ProductEvaluations { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
