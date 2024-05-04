using ERP.EvaluationManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace ERP.EvaluationManagement.DataService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ModuleOfferingTeacher>()
                .HasKey(mt => new { mt.ModuleOfferingId, mt.TeacherId });

            modelBuilder.Entity<ModuleOfferingTeacher>()
                .HasOne(mt => mt.ModuleOffering)
                .WithMany(mt => mt.Teachers)
                .HasForeignKey(mt => mt.ModuleOfferingId);
     

            modelBuilder.Entity<ModuleOfferingTeacher>()
                .HasOne(mt => mt.Teacher)
                .WithMany(mt => mt.TeachingModules)
                .HasForeignKey(mt => mt.TeacherId);


            modelBuilder.Entity<ModuleOfferingFirstExaminer>()
                .HasKey(mf => new {mf.ModuleOfferingId,mf.TeacherId});

            modelBuilder.Entity<ModuleOfferingFirstExaminer>()
                .HasOne(mf => mf.ModuleOffering)
                .WithMany(mf => mf.FirstExaminers)
                .HasForeignKey(mf => mf.ModuleOfferingId);

            modelBuilder.Entity<ModuleOfferingFirstExaminer>()
                .HasOne(mf => mf.Teacher)
                .WithMany(mf => mf.FirstExaminersModules)
                .HasForeignKey(mf =>mf.TeacherId);


            modelBuilder.Entity<ModuleOfferingSecondExaminer>()
                .HasKey(ms => new { ms.ModuleOfferingId, ms.TeacherId });

            modelBuilder.Entity<ModuleOfferingSecondExaminer>()
                .HasOne(ms => ms.ModuleOffering)
                .WithMany(ms => ms.SecondExaminers)
                .HasForeignKey(ms => ms.ModuleOfferingId);

            modelBuilder.Entity<ModuleOfferingSecondExaminer>()
                .HasOne(ms => ms.Teacher)
                .WithMany(ms => ms.SecondExaminersModules)
                .HasForeignKey(ms => ms.TeacherId);
            
            //PK for StudentResult
            modelBuilder.Entity<StudentResult>().HasKey(sr => new { sr.StudentId, sr.EvaluationId });
            
            //PK for Evaluation
            modelBuilder.Entity<Evaluation>().HasKey(e => new { e.Id });
            
            // Student and StudentResult (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentResults)
                .WithOne(sr => sr.Student)
                .HasForeignKey(sr => sr.StudentId);

            // Evaluation and StudentResult (One-to-Many)
            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.Results) 
                .WithOne(sr => sr.Evaluation)
                .HasForeignKey(sr => sr.EvaluationId);
            
            // ModuleOffering and Evaluation (One-to-Many)
            modelBuilder.Entity<ModuleOffering>()
                .HasMany(e => e.Evaluations)
                .WithOne(mo => mo.ModuleOffering)
                .HasForeignKey(mo => mo.ModuleOfferingID); 
            
            // Student and ModuleRegistration (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.ModuleRegistrations)
                .WithOne(mr => mr.Student)
                .HasForeignKey(mr => mr.StudentId);

            // ModuleOffering and ModuleRegistration (One-to-Many)
            modelBuilder.Entity<ModuleOffering>()
                .HasMany(mo => mo.Registrations)
                .WithOne(mr => mr.ModuleOffering)
                .HasForeignKey(mr => mr.ModuleOfferingId);

        // Batch and BatchStudent (One-to-Many)
        modelBuilder.Entity<Batch>()
            .HasMany(bs => bs.BatchStudents)
            .WithOne(b => b.Batch)
            .HasForeignKey(n => n.BatchId);

        // Teacher and Academic Advicee (One-to-Many)
        modelBuilder.Entity<Teacher>()
            .HasMany(a => a.AcademicAdvicees)
            .WithOne(a => a.AcademicAdvisor)
            .HasForeignKey(n => n.AcademicAdvisorId);

    }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<ModuleOffering> ModuleOfferings { get; set; }
        public virtual DbSet<ModuleOfferingTeacher> ModuleTeachers { get; set;}
        public virtual DbSet<ModuleOfferingFirstExaminer> ModuleFirstExaminers { get; set; }
        public virtual DbSet<ModuleOfferingSecondExaminer> ModuleSecondExaminers { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<StudentResult> StudentResults { get; set; }
        public virtual DbSet<ModuleRegistration> ModuleRegistrations { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }

}