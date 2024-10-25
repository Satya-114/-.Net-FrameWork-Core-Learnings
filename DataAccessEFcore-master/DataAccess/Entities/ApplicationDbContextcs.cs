using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Practice> Practices { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    public DbSet<DepartmentProject> DepartmentProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        modelBuilder.Entity<DepartmentProject>()
            .HasKey(dp => new { dp.DepartmentId, dp.ProjectId });

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId);

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);

        modelBuilder.Entity<DepartmentProject>()
            .HasOne(dp => dp.Department)
            .WithMany(d => d.DepartmentProjects)
            .HasForeignKey(dp => dp.DepartmentId);

        modelBuilder.Entity<DepartmentProject>()
            .HasOne(dp => dp.Project)
            .WithMany(p => p.DepartmentProjects)
            .HasForeignKey(dp => dp.ProjectId);
    }
}
