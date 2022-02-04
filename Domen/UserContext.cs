using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiFusion.Data
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = FusionUserApi; ");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(u => new { u.UserId });

            modelBuilder.Entity<Role>().HasKey(r => new { r.RoleId });

            modelBuilder.Entity<Permission>().HasKey(p => new {p.PermissionId });

            //modelBuilder.Entity<Role>()
            //    .HasOne(r => r.User)
            //    .WithMany(u => u.Roles).IsRequired(true);

            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithOne(r => r.User).IsRequired(true);

            //modelBuilder.Entity<Permission>()
            //    .HasOne(p => p.Role)
            //    .WithMany(u => u.Permissions).IsRequired(true);

            modelBuilder.Entity<Role>().HasMany(r => r.Permissions).WithOne(p => p.Role).IsRequired(true);
        }


    }
}
