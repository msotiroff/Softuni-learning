namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(100).IsUnicode(true);
                entity.Property(e => e.PhoneNumber).IsRequired(false).HasColumnType("CHAR(10)").IsUnicode(false);
                entity.Property(e => e.RegisteredOn).IsRequired(true).HasColumnType("DATETIME2");
                entity.Property(e => e.Birthday).IsRequired(false).HasColumnType("DATETIME2");

                entity.HasMany(s => s.CourseEnrollments)
                    .WithOne(c => c.Student)
                    .HasForeignKey(s => s.CourseId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(80).IsUnicode(true);
                entity.Property(e => e.Description).IsRequired(false).IsUnicode(true);
                entity.Property(e => e.StartDate).IsRequired(true).HasColumnType("DATETIME2");
                entity.Property(e => e.EndDate).IsRequired(true).HasColumnType("DATETIME2");

                entity.HasMany(c => c.StudentsEnrolled)
                    .WithOne(s => s.Course)
                    .HasForeignKey(ce => ce.StudentId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(50).IsUnicode(true);
                entity.Property(e => e.Url).IsRequired(false).IsUnicode(false);

                entity.HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.ToTable("HomeworkSubmissions");

                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content).IsRequired(true).IsUnicode(false);
                entity.Property(e => e.SubmissionTime).IsRequired(true).HasColumnType("DATETIME2");

                entity.HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("StudentCourses");

                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
