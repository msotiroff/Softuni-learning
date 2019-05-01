namespace SoftUniClone.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SoftUniClone.Models;

    public class SoftUniCloneDbContext : IdentityDbContext<User>
    {
        public SoftUniCloneDbContext(DbContextOptions<SoftUniCloneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            builder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);

            builder
                .Entity<Course>()
                .HasOne(c => c.Lecturer)
                .WithMany(t => t.Trainings)
                .HasForeignKey(c => c.LecturerId);
            
            base.OnModelCreating(builder);
        }
    }
}
