using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domen
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
        public DbSet<UserRole> userRole { get; set; }
        public DbSet<RolePermission> rolePermission { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = FusionDB; ");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(u => new { u.UserId });

            modelBuilder.Entity<Role>().HasKey(r => new { r.RoleId });

            modelBuilder.Entity<Permission>().HasKey(p => new {p.PermissionId });

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId,rp.PermissionId });




            //modelBuilder.Entity<User>().HasMany(u => u.UserRoles).WithOne(r => r.User).IsRequired(true).OnDelete(DeleteBehavior.NoAction);



            //modelBuilder.Entity<Role>().HasMany(r => r.RolePermissions).WithOne(p => p.Role).IsRequired(true).OnDelete(DeleteBehavior.NoAction);
        }


    }
}
