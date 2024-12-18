using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using asm.Models;

namespace asm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<asm.Models.Address> Address { get; set; }
        public DbSet<asm.Models.Course> Course { get; set; }
        public DbSet<asm.Models.Enrolment> Enrolment { get; set; }
        public DbSet<asm.Models.Lecturer> Lecturer { get; set; }
        public DbSet<asm.Models.Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(c => c.Address)
                .WithOne(e => e.Student)
                .HasForeignKey<Address>(e => e.AddressID);
            builder.Entity<Student>()
                .HasMany(e => e.Enrolments)
                .WithOne(c=> c.Student)
                .HasForeignKey(e => e.EnrolmentID);
            builder.Entity<Course>()
                .HasMany(e => e.Enrolments)
                .WithOne(c => c.Course)
                .HasForeignKey(e => e.EnrolmentID);
            builder.Entity<Lecturer>()
                .HasMany(e => e.Courses)
                .WithOne(c => c.Lecturer)
                .HasForeignKey(c => c.LecturerID);

        }
    }
}
