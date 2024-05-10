using ERP.RequestManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace ERP.RequestManagement.DataService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        // Teacher and Academic Advicee (One-to-Many)
        modelBuilder.Entity<Teacher>()
            .HasMany(a => a.AcademicAdvicees)
            .WithOne(a => a.AcademicAdvisor)
            .HasForeignKey(n => n.AcademicAdvisorId);

        // Batch and BatchStudent (One-to-Many)
        modelBuilder.Entity<Batch>()
            .HasMany(bs => bs.BatchStudents)
            .WithOne(b => b.Batch)
            .HasForeignKey(n => n.BatchId);

        // Student and SOutgoingRequest (One-to-Many)
        modelBuilder.Entity<Student>()
            .HasMany(sr => sr.SOutgoingRequests)
            .WithOne(s => s.Sender)
            .HasForeignKey(N => N.SenderId);

        // Student and SIncomingRequest (One-to-Many)
        modelBuilder.Entity<Student>()
            .HasMany(sr => sr.SIncomingRequests)
            .WithOne(s => s.Reciever)
            .HasForeignKey(N => N.RecieverId);

        // Teacher and TOutgoingRequest (One-to-Many)
        modelBuilder.Entity<Teacher>()
            .HasMany(sr => sr.TOutgoingRequests)
            .WithOne(s => s.Sender)
            .HasForeignKey(N => N.SenderId);

        // Teacher and TIncomingRequest (One-to-Many)
        modelBuilder.Entity<Teacher>()
            .HasMany(sr => sr.TIncomingRequests)
            .WithOne(s => s.Reciever)
            .HasForeignKey(N => N.RecieverId);

        //// Teacher and OutgoingStaffRequests (One-to-Many)
        //modelBuilder.Entity<Teacher>()
        //    .HasMany(sr => sr.OutgoingStaffRequests)
        //    .WithOne(s => s.Sender)
        //    .HasForeignKey(N => N.SenderId);

        //// Teacher and IncomingStaffRequests (One-to-Many)
        //modelBuilder.Entity<Teacher>()
        //    .HasMany(sr => sr.IncomingStaffRequests)
        //    .WithOne(s => s.Reciever)
        //    .HasForeignKey(N => N.RecieverId);

    }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<TeacherRequest> TeacherRequests { get; set; }
        public virtual DbSet<StudentRequest> StudentRequests { get; set; }
        public virtual DbSet<StaffRequest> StaffRequests { get; set; }

}