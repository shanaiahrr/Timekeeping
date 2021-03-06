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
    [Migration("20190109020017_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityType");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Department");

                    b.Property<string>("EmployeeStatus");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<int>("HDMFno");

                    b.Property<DateTime>("HiredDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<int>("PHICno");

                    b.Property<string>("Position");

                    b.Property<string>("Project");

                    b.Property<int>("SSSno");

                    b.Property<DateTime>("SeparatedDate");

                    b.Property<string>("Shift");

                    b.Property<int>("TINno");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
