﻿// <auto-generated />
using System;
using KindyCity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    [DbContext(typeof(KindyCityContext))]
    [Migration("20241231093954_initial-version-6")]
    partial class initialversion6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KindyCity.Domain.Entites.DefautlPermission", b =>
                {
                    b.Property<Guid>("DefautlPermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DefautlPermissionId");

                    b.ToTable("DefautlPermissions");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentId");

                    b.HasIndex("LocationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.DistrictCategory", b =>
                {
                    b.Property<Guid>("DistrictCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DistrictCategoryId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("DistrictCategories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("Employee_OperationEmployeeAction")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastSignInTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Employee_OperationEmployeeAction");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EmployeeEducation", b =>
                {
                    b.Property<Guid>("EmployeeEducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeEducationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeEducations");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EmployeeInfo", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CitizenIDIssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CitizenIDIssuedPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("CurrentAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("EmergencyContactPersonName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("EmergencyContactPersonPhone")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("EmergencyContactRelationship")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("EthnicityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte>("IsVietnamese")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MaritalStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Nationlity")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("PassportIssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PassportIssuedEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportIssuedPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PlaceOfOrigin")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("ResidenceDistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResidenceProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResidenceStreetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResidenceWardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Sex")
                        .HasColumnType("tinyint");

                    b.Property<string>("Skype")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte>("WorkingStatus")
                        .HasColumnType("tinyint");

                    b.HasKey("EmployeeId");

                    b.ToTable("EmployeeInfos");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Employee_Operation", b =>
                {
                    b.Property<Guid>("EmployeeAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeAction");

                    b.ToTable("Employee_Action");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EthnicityCategory", b =>
                {
                    b.Property<Guid>("EthnicityCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EthnicityName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EthnicityCategoryId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EthnicityCategories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Feature", b =>
                {
                    b.Property<Guid>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FeatureId");

                    b.HasIndex("MenuId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sort"));

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Menu", b =>
                {
                    b.Property<Guid>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<int>("MenuCode")
                        .HasColumnType("int");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MenuId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Operation", b =>
                {
                    b.Property<Guid>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("DefautlPermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Employee_OperationEmployeeAction")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OperationId");

                    b.HasIndex("DefautlPermissionId");

                    b.HasIndex("Employee_OperationEmployeeAction");

                    b.HasIndex("FeatureId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Position", b =>
                {
                    b.Property<Guid>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DefautlPermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PositionCode")
                        .HasColumnType("int");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PositionId");

                    b.HasIndex("DefautlPermissionId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.ProvinceCategory", b =>
                {
                    b.Property<Guid>("ProvinceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ProvinceCategoryId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("ProvinceCategories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Service", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.StreetCategory", b =>
                {
                    b.Property<Guid>("StreetCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StreetCategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("StreetCategoryId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("StressCategories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.WardCategory", b =>
                {
                    b.Property<Guid>("WardCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WardName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("WardCategoryId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("WardCategories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.WorkHistory", b =>
                {
                    b.Property<Guid>("WorkHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Del")
                        .HasColumnType("bit");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkHistoryId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("WorkHistories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Department", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.DistrictCategory", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.EmployeeInfo", "EmployeeInfo")
                        .WithOne("DistrictCategories")
                        .HasForeignKey("KindyCity.Domain.Entites.DistrictCategory", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Employee", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Employee_Operation", null)
                        .WithMany("Employee")
                        .HasForeignKey("Employee_OperationEmployeeAction");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EmployeeEducation", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EmployeeInfo", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Employee", "Employee")
                        .WithOne("EmployeeInfo")
                        .HasForeignKey("KindyCity.Domain.Entites.EmployeeInfo", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EthnicityCategory", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.EmployeeInfo", "EmployeeInfo")
                        .WithOne("EthnicityCategories")
                        .HasForeignKey("KindyCity.Domain.Entites.EthnicityCategory", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Feature", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Menu", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Operation", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.DefautlPermission", null)
                        .WithMany("Operation")
                        .HasForeignKey("DefautlPermissionId");

                    b.HasOne("KindyCity.Domain.Entites.Employee_Operation", null)
                        .WithMany("Action")
                        .HasForeignKey("Employee_OperationEmployeeAction");

                    b.HasOne("KindyCity.Domain.Entites.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Position", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.DefautlPermission", null)
                        .WithMany("Position")
                        .HasForeignKey("DefautlPermissionId");

                    b.HasOne("KindyCity.Domain.Entites.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.ProvinceCategory", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.EmployeeInfo", "EmployeeInfo")
                        .WithOne("ProvinceCategories")
                        .HasForeignKey("KindyCity.Domain.Entites.ProvinceCategory", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.StreetCategory", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.EmployeeInfo", "EmployeeInfo")
                        .WithOne("StreetCategories")
                        .HasForeignKey("KindyCity.Domain.Entites.StreetCategory", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.WardCategory", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.EmployeeInfo", "EmployeeInfo")
                        .WithOne("WardCategories")
                        .HasForeignKey("KindyCity.Domain.Entites.WardCategory", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.WorkHistory", b =>
                {
                    b.HasOne("KindyCity.Domain.Entites.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KindyCity.Domain.Entites.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.DefautlPermission", b =>
                {
                    b.Navigation("Operation");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Employee", b =>
                {
                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.EmployeeInfo", b =>
                {
                    b.Navigation("DistrictCategories");

                    b.Navigation("EthnicityCategories");

                    b.Navigation("ProvinceCategories");

                    b.Navigation("StreetCategories");

                    b.Navigation("WardCategories");
                });

            modelBuilder.Entity("KindyCity.Domain.Entites.Employee_Operation", b =>
                {
                    b.Navigation("Action");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
