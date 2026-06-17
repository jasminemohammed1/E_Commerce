using E_Commerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data
{
    internal class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product>  Products { get; set; }
        public DbSet<ProductType> ProductTypes {  get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}
