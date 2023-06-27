using EventuresApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD
using EventuresApp.Models;
=======
>>>>>>> c8cd4aa8cf956f70ec44df258c3daeb04f16c10b

namespace EventuresApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventuresUser>
    {
<<<<<<< HEAD
=======
      //  public DbSet<Event> Events { get; set; }
>>>>>>> c8cd4aa8cf956f70ec44df258c3daeb04f16c10b
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Event> Events { get; set; }
<<<<<<< HEAD
        public DbSet<Order> Orders { get; set; }
        public DbSet<EventuresApp.Models.OrderListingViewModel> OrderListingViewModel { get; set; }
=======
>>>>>>> c8cd4aa8cf956f70ec44df258c3daeb04f16c10b
    }
}
