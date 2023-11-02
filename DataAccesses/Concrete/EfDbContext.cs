using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesses.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductProperty>().HasOptional(p => p.Product)
            //    .WithMany(pp => pp.ProductProperties).HasForeignKey(p => p.ProductId);

            //modelBuilder.Entity<ProductProperty>().HasOptional(p => p.Property)
            //   .WithMany(pp => pp.ProductProperties).HasForeignKey(p => p.PropertyId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
