using CatAppWeb.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatAppWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatAppWeb.Models.CatAllViewModel> CatAllViewModel { get; set; }
        public DbSet<CatAppWeb.Models.CatCreateViewModel> CatCreateViewModel { get; set; }
    }
}
