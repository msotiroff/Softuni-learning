namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(
                entity =>
                {
                    entity.HasKey(e => e.PatientId);

                    entity.Property(e => e.PatientId).HasColumnName("PatientID");
                    entity.Property(e => e.FirstName).IsRequired(true).HasMaxLength(50).IsUnicode(true);
                    entity.Property(e => e.LastName).IsRequired(true).HasMaxLength(50).IsUnicode(true);
                    entity.Property(e => e.Address).IsRequired(true).HasMaxLength(250).IsUnicode(true);
                    entity.Property(e => e.Email).IsRequired(true).HasMaxLength(80).IsUnicode(false);
                    entity.Property(e => e.HasInsurance).HasDefaultValue(true);
                });


            modelBuilder.Entity<Diagnose>(
                entity =>
                {
                    entity.HasKey(e => e.DiagnoseId);

                    entity.Property(e => e.DiagnoseId).HasColumnName("DiagnoseID");
                    entity.Property(e => e.Name).IsRequired(true).HasMaxLength(50).IsUnicode(true);
                    entity.Property(e => e.Comments).IsRequired(false).HasMaxLength(250).IsUnicode(true);

                    entity.HasOne(d => d.Patient)
                    .WithMany(e => e.Diagnoses)
                    .HasForeignKey(d => d.PatientId);
                });


            modelBuilder.Entity<Visitation>(
                entity =>
                {
                    entity.HasKey(e => e.VisitationId);

                    entity.Property(e => e.PatientId).HasColumnName("PatientID");
                    entity.Property(e => e.Date).IsRequired(true).HasColumnType("DATETIME2").HasDefaultValueSql("GETDATE()");
                    entity.Property(e => e.Comments).IsRequired(false).HasMaxLength(250).IsUnicode(true);
                    entity.Property(e => e.DoctorId).IsRequired(false).HasDefaultValue(null);

                    entity.HasOne(v => v.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(v => v.PatientId);

                    entity.HasOne(v => v.Doctor)
                    .WithMany(d => d.Visitations)
                    .HasForeignKey(v => v.DoctorId);
                });

            modelBuilder.Entity<Doctor>(
                entity =>
                {
                    entity.HasKey(e => e.DoctorId);

                    entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
                    entity.Property(e => e.Name).IsRequired(true).HasMaxLength(100).IsUnicode(true);
                    entity.Property(e => e.Specialty).IsRequired(true).HasMaxLength(100).IsUnicode(true);                    
                });


            modelBuilder.Entity<Medicament>(
                entity =>
                {
                    entity.HasKey(e => e.MedicamentId);

                    entity.Property(e => e.MedicamentId).HasColumnName("MedicamentID");
                    entity.Property(e => e.Name).IsRequired(true).HasMaxLength(50).IsUnicode(true);
                });


            modelBuilder.Entity<PatientMedicament>(
                entity =>
                {
                    entity.ToTable("PatientsMedicaments");

                    entity.HasKey(e => new { e.PatientId, e.MedicamentId });

                    entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Cascade);

                    entity.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(e => e.MedicamentId)
                    .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
