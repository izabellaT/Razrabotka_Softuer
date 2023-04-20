using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=ProductDb");
        }
        public DbSet<Product> Products { get; set; }
    }
}
