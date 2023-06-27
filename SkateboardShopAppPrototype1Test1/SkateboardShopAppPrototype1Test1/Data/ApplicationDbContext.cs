using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkateboardShopAppPrototype1Test1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkateboardShopAppPrototype1Test1.Data
{
    public class ApplicationDbContext : IdentityDbContext<SkateboardsUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Skateboard> Skateboards { get; set; }
    }
}
