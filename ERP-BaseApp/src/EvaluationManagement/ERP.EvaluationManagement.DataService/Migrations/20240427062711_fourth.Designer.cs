﻿// <auto-generated />
using System;
using ERP.EvaluationManagement.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERP.EvaluationManagement.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240427062711_fourth")]
    partial class fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4");

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("FinalMarks")
                        .HasColumnType("REAL");

                    b.Property<double>("Marks")
                        .HasColumnType("REAL");

                    b.Property<Guid>("ModuleOfferingID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModuleOfferingID");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOffering", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CoordinatorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExternalModeratorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModeratorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("ExternalModeratorId");

                    b.HasIndex("ModeratorId");

                    b.HasIndex("ModuleId");

                    b.ToTable("ModuleOfferings");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOfferingFirstExaminer", b =>
                {
                    b.Property<Guid>("ModuleOfferingId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ModuleOfferingId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ModuleFirstExaminers");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOfferingSecondExaminer", b =>
                {
                    b.Property<Guid>("ModuleOfferingId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ModuleOfferingId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ModuleSecondExaminers");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOfferingTeacher", b =>
                {
                    b.Property<Guid>("ModuleOfferingId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("TEXT");

                    b.HasKey("ModuleOfferingId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ModuleTeachers");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleRegistration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModuleOfferingId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModuleOfferingId");

                    b.HasIndex("StudentId");

                    b.ToTable("ModuleRegistrations");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Student", b =>
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

                    b.Property<string>("RegistrationNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.StudentResult", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EvaluationId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<double>("StudentScore")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId", "EvaluationId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("StudentResults");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Teacher", b =>
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

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Evaluation", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.ModuleOffering", "ModuleOffering")
                        .WithMany("Evaluations")
                        .HasForeignKey("ModuleOfferingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuleOffering");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOffering", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Teacher", "Coordinator")
                        .WithMany("CordinatingModules")
                        .HasForeignKey("CoordinatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Teacher", "ExternalModerator")
                        .WithMany()
                        .HasForeignKey("ExternalModeratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Teacher", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinator");

                    b.Navigation("ExternalModerator");

                    b.Navigation("Moderator");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOfferingFirstExaminer", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.ModuleOffering", "ModuleOffering")
                        .WithMany("FirstExaminers")
                        .HasForeignKey("ModuleOfferingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Teacher", "Teacher")
                        .WithMany("FirstExaminersModules")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuleOffering");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOfferingSecondExaminer", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.ModuleOffering", "ModuleOffering")
                        .WithMany("SecondExaminers")
                        .HasForeignKey("ModuleOfferingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Teacher", "Teacher")
                        .WithMany("SecondExaminersModules")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuleOffering");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOfferingTeacher", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.ModuleOffering", "ModuleOffering")
                        .WithMany("Teachers")
                        .HasForeignKey("ModuleOfferingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Teacher", "Teacher")
                        .WithMany("TeachingModules")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuleOffering");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleRegistration", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.ModuleOffering", "ModuleOffering")
                        .WithMany("Registrations")
                        .HasForeignKey("ModuleOfferingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Student", "Student")
                        .WithMany("ModuleRegistrations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuleOffering");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.StudentResult", b =>
                {
                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Evaluation", "Evaluation")
                        .WithMany("Results")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.EvaluationManagement.Core.Entity.Student", "Student")
                        .WithMany("StudentResults")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluation");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Evaluation", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.ModuleOffering", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("FirstExaminers");

                    b.Navigation("Registrations");

                    b.Navigation("SecondExaminers");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Student", b =>
                {
                    b.Navigation("ModuleRegistrations");

                    b.Navigation("StudentResults");
                });

            modelBuilder.Entity("ERP.EvaluationManagement.Core.Entity.Teacher", b =>
                {
                    b.Navigation("CordinatingModules");

                    b.Navigation("FirstExaminersModules");

                    b.Navigation("SecondExaminersModules");

                    b.Navigation("TeachingModules");
                });
#pragma warning restore 612, 618
        }
    }
}
