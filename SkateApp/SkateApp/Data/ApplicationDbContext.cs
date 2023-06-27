using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkateApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using SkateApp.Models;
using SkateApp.Models.Skateboard;

namespace SkateApp.Data
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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


        public DbSet<SkateApp.Models.Accessorie.AccessoriesAllViewModel> AccessoriesAllViewModel { get; set; }
        public DbSet<SkateApp.Models.Accessorie.AccessoriesDetailsViewModel> AccessoriesDetailsViewModel { get; set; }
        public DbSet<SkateApp.Models.Skateboard.SkateboardAllViewModel> SkateboardAllViewModel { get; set; }
        public DbSet<SkateApp.Models.Skateboard.SkateboardDetailsViewModel> SkateboardDetailsViewModel { get; set; }
        public DbSet<SkateApp.Models.OrderListingViewModel> OrderListingViewModel { get; set; }
        public DbSet<SkateApp.Models.FavoriteListingViewModel> FavoriteListingViewModels { get; set; }
        public DbSet<SkateApp.Models.Skateboard.SkateboardCreateViewModel> SkateboardCreateViewModel { get; set; }
    }
}
