using KindyCity.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace KindyCity.Infrastructure.Data
{
    public class KindyCityContext : DbContext
    {
        public KindyCityContext(DbContextOptions<KindyCityContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public virtual DbSet<EthnicityCategory> EthnicityCategories { get; set; }
        public virtual DbSet<ProvinceCategory> ProvinceCategories { get; set; }
        public virtual DbSet<WardCategory> WardCategories { get; set; }
        public virtual DbSet<StreetCategory> StressCategories { get; set; }
        public virtual DbSet<DistrictCategory> DistrictCategories { get; set; }
        public virtual DbSet<WorkHistory> WorkHistories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<DefautlPermission> DefautlPermissions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Employee_Operation> Employee_Operation { get; set; }
        public virtual DbSet<EmployeeRefreshToken> EmployeeRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeInfo)
                .WithOne(ei => ei.Employee)
                .HasForeignKey<EmployeeInfo>(ei => ei.EmployeeId);
            modelBuilder.Entity<EthnicityCategory>()
                .HasOne(dc => dc.EmployeeInfo)
                .WithOne(ei => ei.EthnicityCategories)
                .HasForeignKey<EthnicityCategory>(dc => dc.EmployeeId);
            modelBuilder.Entity<ProvinceCategory>()
                .HasOne(dc => dc.EmployeeInfo)
                .WithOne(ei => ei.ProvinceCategories)
                .HasForeignKey<ProvinceCategory>(dc => dc.EmployeeId);
            modelBuilder.Entity<DistrictCategory>()
                .HasOne(dc => dc.EmployeeInfo)
                .WithOne(ei => ei.DistrictCategories)
                .HasForeignKey<DistrictCategory>(dc => dc.EmployeeId);
            modelBuilder.Entity<WardCategory>()
                .HasOne(dc => dc.EmployeeInfo)
                .WithOne(ei => ei.WardCategories)
                .HasForeignKey<WardCategory>(dc => dc.EmployeeId);
            modelBuilder.Entity<StreetCategory>()
                .HasOne(dc => dc.EmployeeInfo)
                .WithOne(ei => ei.StreetCategories)
                .HasForeignKey<StreetCategory>(dc => dc.EmployeeId);
        }
    }
}
