using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMvcExamples.Data
{
    public class OnlineShopDb : DbContext
    {
        public OnlineShopDb() : base("name=OnlineShopDb")
        {
        }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }

        public System.Data.Entity.DbSet<AspNetMvcExamples.Models.CreateProductViewModel> CreateProductViewModels { get; set; }
    }
}