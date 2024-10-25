﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240930064934_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DataAccess.Entities.DepartmentProject", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("DepartmentProjects");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PracticeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("DataAccess.Entities.Practice", b =>
                {
                    b.Property<int>("PracticeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PracticeId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("PracticeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PracticeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Practices");
                });

            modelBuilder.Entity("DataAccess.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DataAccess.Entities.DepartmentProject", b =>
                {
                    b.HasOne("DataAccess.Entities.Department", "Department")
                        .WithMany("DepartmentProjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Project", "Project")
                        .WithMany("DepartmentProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.HasOne("DataAccess.Entities.Practice", "Practice")
                        .WithMany("Employees")
                        .HasForeignKey("PracticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Practice");
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeProject", b =>
                {
                    b.HasOne("DataAccess.Entities.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DataAccess.Entities.Practice", b =>
                {
                    b.HasOne("DataAccess.Entities.Department", "Department")
                        .WithMany("Practices")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DataAccess.Entities.Department", b =>
                {
                    b.Navigation("DepartmentProjects");

                    b.Navigation("Practices");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("DataAccess.Entities.Practice", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DataAccess.Entities.Project", b =>
                {
                    b.Navigation("DepartmentProjects");

                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
