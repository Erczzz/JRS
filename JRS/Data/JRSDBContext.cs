using Microsoft.EntityFrameworkCore;
using JRS.Models;

namespace JRS.Data
{
    public class JRSDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "Server = (localdb)\\MSSQLLocalDB;Database=JRSNewDB;Integrated Security=true;";
            optionsBuilder.UseSqlServer(con).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne<Role>(x => x.Role)
            .WithMany(x => x.Users).HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

            var adminRole = new Role { RoleId = 1, RoleName = "Administrator" };
            var employeeRole = new Role { RoleId = 2, RoleName = "Employee" };
            var customerRole = new Role { RoleId = 3, RoleName = "Customer" };

            modelBuilder.Entity<Role>()
                .HasData(adminRole, employeeRole, customerRole);

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    UserId = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    BirthDate = new DateTime(1999, 2, 12),
                    ContactNo = "09920098321",
                    Email = "admin@email.com",
                    Address = "SampleAddress",
                    Username = "admin",
                    RoleId = adminRole.RoleId
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
