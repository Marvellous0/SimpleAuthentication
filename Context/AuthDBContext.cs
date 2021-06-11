using Microsoft.EntityFrameworkCore;
using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Context
{
    public class AuthDBContext : DbContext
    {
        public AuthDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set;  }
        public DbSet<Instructor> Instructors { get; set; }

        public override int SaveChanges()
        {
            Console.WriteLine("Saving changes");

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Student).WithOne(s => s.User);

            modelBuilder.Entity<User>().HasOne(u => u.Instructor).WithOne(i => i.User);

            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();


            modelBuilder.Entity<User>().Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Student>().HasKey(s => s.UserId);


            modelBuilder.Entity<Student>().HasIndex(s => s.UserId).IsUnique();

            modelBuilder.Entity<Instructor>().HasKey(i => i.UserId);

            modelBuilder.Entity<Instructor>().HasIndex(s => s.UserId).IsUnique();

            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany(r => r.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
