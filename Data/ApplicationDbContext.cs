using System;
using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Models;


namespace StudentDemoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.Email)
                      .IsRequired();

                entity.HasIndex(s => s.Email)
                      .IsUnique();
                
                // 1-M: Student → Course
                entity.HasOne(s => s.Course)
                      .WithMany(c => c.Students)
                      .HasForeignKey(s => s.CourseId)
                      .OnDelete(DeleteBehavior.SetNull);

                // 1-1: Student → Profile
                entity.HasOne(s => s.Profile)
                      .WithOne(p => p.Student)
                      .HasForeignKey<StudentProfile>(p => p.StudentId);

            });
                // M-M: Student ↔ Club
            modelBuilder.Entity<Student>()
                        .HasMany(s => s.Clubs)
                        .WithMany(c => c.Students)
                        .UsingEntity(j => j.ToTable("StudentClubs"));

        }
    }
    
}