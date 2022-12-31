using Employee.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {

        }
        public StoreContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-E3KK8N8;Database=EmployeeSystem;Trusted_connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee.Domain.Model.Employees>().HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Employee.Domain.Model.Employees>(x => x.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee.Domain.Model.Employees> Employees { get; set; }
       // public DbSet<> Employees { get; set; }

    }
}
