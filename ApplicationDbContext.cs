using Microsoft.EntityFrameworkCore;
using PROG.Models;
using System.Reflection.Emit;

namespace PROG.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "farmer1@example.com", Password = "Password123!", Role = "Farmer" },
                new User { UserId = 2, Email = "employee1@example.com", Password = "Password123!", Role = "Employee" }
                );
        }
    }
}
