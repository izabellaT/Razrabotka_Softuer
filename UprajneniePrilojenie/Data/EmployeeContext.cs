using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=FirmDb");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
