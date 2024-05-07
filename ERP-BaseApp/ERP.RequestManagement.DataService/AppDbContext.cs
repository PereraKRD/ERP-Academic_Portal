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

    }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

}