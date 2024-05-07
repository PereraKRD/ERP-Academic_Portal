﻿// <auto-generated />
using System;
using ERP.RequestManagement.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.RequestManagement.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240507165949_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4");

            modelBuilder.Entity("ERP.RequestManagement.Core.Entity.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AcademicAdvisorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AcademicAdvisorId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ERP.RequestManagement.Core.Entity.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ERP.RequestManagement.Core.Entity.Student", b =>
                {
                    b.HasOne("ERP.RequestManagement.Core.Entity.Teacher", "AcademicAdvisor")
                        .WithMany("AcademicAdvicees")
                        .HasForeignKey("AcademicAdvisorId");

                    b.Navigation("AcademicAdvisor");
                });

            modelBuilder.Entity("ERP.RequestManagement.Core.Entity.Teacher", b =>
                {
                    b.Navigation("AcademicAdvicees");
                });
#pragma warning restore 612, 618
        }
    }
}
