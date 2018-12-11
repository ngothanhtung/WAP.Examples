using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopMvcWeb.Data
{
    public class OnlineShopDb : DbContext
    {
        public OnlineShopDb() : base("DefaultConnection")
        {
        }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //modelBuilder.Entity<Product>()
            //    .Property(e => e.Price)
            //    .HasPrecision(19, 4);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
    }
}