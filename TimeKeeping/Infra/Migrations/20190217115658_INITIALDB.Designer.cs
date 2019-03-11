﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(TimeKeepingDBContext))]
    [Migration("20190217115658_INITIALDB")]
    partial class INITIALDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.ActivityType", b =>
                {
                    b.Property<Guid>("Activity_TypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity_Type")
                        .IsRequired();

                    b.HasKey("Activity_TypeID");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("Domain.Models.Days", b =>
                {
                    b.Property<Guid>("DayID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Day");

                    b.HasKey("DayID");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Domain.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName")
                        .IsRequired();

                    b.Property<string>("Department_Code")
                        .IsRequired();

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("CostCenter");

                    b.Property<string>("Department");

                    b.Property<string>("EmployeeStatus");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("HDMFno")
                        .IsRequired();

                    b.Property<DateTime>("HiredDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("PHICno")
                        .IsRequired();

                    b.Property<string>("Position");

                    b.Property<string>("Project");

                    b.Property<Guid>("RoleID");

                    b.Property<string>("SSSno")
                        .IsRequired();

                    b.Property<DateTime>("SeparatedDate");

                    b.Property<string>("Shift");

                    b.Property<string>("TINno")
                        .IsRequired();

                    b.HasKey("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Domain.Models.Rights", b =>
                {
                    b.Property<Guid>("RightID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameofRight")
                        .IsRequired();

                    b.Property<Guid>("TypeID");

                    b.HasKey("RightID");

                    b.HasIndex("TypeID");

                    b.ToTable("Right");
                });

            modelBuilder.Entity("Domain.Models.RoleRights", b =>
                {
                    b.Property<Guid>("Role_RightID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RightID");

                    b.Property<Guid>("RoleID");

                    b.HasKey("Role_RightID");

                    b.HasIndex("RightID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleRight");
                });

            modelBuilder.Entity("Domain.Models.Roles", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Domain.Models.Shifts", b =>
                {
                    b.Property<Guid>("ShiftID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DayID");

                    b.Property<DateTime>("End_Time");

                    b.Property<string>("Shift_Type")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("Start_Time");

                    b.HasKey("ShiftID");

                    b.HasIndex("DayID");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("Domain.Models.TypeofRights", b =>
                {
                    b.Property<Guid>("Role_TypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Role_Type")
                        .IsRequired();

                    b.HasKey("Role_TypeID");

                    b.ToTable("TypeofRight");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.HasOne("Domain.Models.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.Rights", b =>
                {
                    b.HasOne("Domain.Models.TypeofRights", "TypeofRight")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.RoleRights", b =>
                {
                    b.HasOne("Domain.Models.Rights", "Right")
                        .WithMany()
                        .HasForeignKey("RightID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Models.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.Shifts", b =>
                {
                    b.HasOne("Domain.Models.Days", "Day")
                        .WithMany()
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
