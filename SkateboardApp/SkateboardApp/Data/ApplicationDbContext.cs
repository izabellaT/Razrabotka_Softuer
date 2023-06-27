using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkateboardApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkateboardApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<SkateboardsUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Skateboard> Skateboards { get; set; }
        public DbSet<Accessorie> Accessories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SkateboardApp.Models.OrderListingViewModel> OrderListingViewModel { get; set; }
    }
}
