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

        // Tables
      public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // STUDENT CONFIGURATION
modelBuilder.Entity<Student>(entity =>
{
    entity.HasKey(s => s.Id);

    entity.Property(s => s.FirstName)
          .IsRequired()
          .HasMaxLength(50);

    entity.Property(s => s.LastName)
          .IsRequired()
          .HasMaxLength(50);

    entity.Property(s => s.Email)
          .IsRequired()
          .HasMaxLength(100);

    entity.HasIndex(s => s.Email)
          .IsUnique();

    entity.Property(s => s.DateOfBirth)
          .IsRequired();

    entity.Property(s => s.Address)
          .HasMaxLength(200);

    entity.Property(s => s.Phone)
          .HasMaxLength(20);

    entity.Property(s => s.CreatedAt)
          .HasDefaultValueSql("GETUTCDATE()");

    entity.HasOne(s => s.Course)
          .WithMany(c => c.Students)
          .HasForeignKey(s => s.CourseId)
          .OnDelete(DeleteBehavior.SetNull);
});
            // TEACHER CONFIGURATION
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.Email)
                      .IsRequired();

                entity.HasIndex(t => t.Email)
                      .IsUnique();
                      
                entity.Property(t => t.Phone)
                      .HasMaxLength(20);

                entity.Property(t => t.Address)
                      .HasMaxLength(250);

                entity.Property(t => t.Education)
                      .HasMaxLength(200);

                entity.HasMany(t => t.Courses)
                      .WithOne(c => c.Teacher)
                      .HasForeignKey(c => c.TeacherId)
                      .OnDelete(DeleteBehavior.SetNull);
            });
            // Course Config
            modelBuilder.Entity<Course>(entity =>
{
    entity.HasKey(c => c.Id);
    entity.Property(c => c.Code).IsRequired().HasMaxLength(50);
    entity.Property(c => c.Name).IsRequired().HasMaxLength(200);
    entity.Property(c => c.Description).HasMaxLength(500);
    entity.Property(c => c.Credits).IsRequired();
    entity.Property(c => c.GradeLevel).IsRequired();
    entity.Property(c => c.IsActive).IsRequired();
    entity.Property(c => c.StartDate).IsRequired();
    entity.Property(c => c.EndDate).IsRequired();

    entity.HasOne(c => c.Teacher)
          .WithMany(t => t.Courses)
          .HasForeignKey(c => c.TeacherId)
          .OnDelete(DeleteBehavior.SetNull);
});

                }
    }
}