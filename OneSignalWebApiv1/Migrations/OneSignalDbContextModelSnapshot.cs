﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneSignalWebApiv1.Context;

#nullable disable

namespace OneSignalWebApiv1.Migrations
{
    [DbContext(typeof(OneSignalDbContext))]
    partial class OneSignalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OneSignalWebApiv1.Entities.CustomSchedule", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CREATEDDATE")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("CREATEDTIME")
                        .HasColumnType("time");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ScheduleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GUID");

                    b.ToTable("CustomSchedules");
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.Homework", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CREATEDDATE")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("CREATEDTIME")
                        .HasColumnType("time");

                    b.Property<string>("HomeworkTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GUID");

                    b.ToTable("Homeworks");

                    b.HasData(
                        new
                        {
                            GUID = new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                            CREATEDDATE = new DateTime(2024, 9, 4, 10, 11, 31, 925, DateTimeKind.Local).AddTicks(3566),
                            CREATEDTIME = new TimeSpan(366919253569),
                            HomeworkTitle = "Matematik 5 soru çöz"
                        },
                        new
                        {
                            GUID = new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                            CREATEDDATE = new DateTime(2024, 9, 4, 10, 16, 31, 925, DateTimeKind.Local).AddTicks(3573),
                            CREATEDTIME = new TimeSpan(366919253573),
                            HomeworkTitle = "Tükçe 105-110 sayfalaro yap"
                        });
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.LiveLesson", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CREATEDDATE")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("CREATEDTIME")
                        .HasColumnType("time");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("STARTDATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("STUDENTIDS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GUID");

                    b.ToTable("LiveLessons");
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.Student", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CREATEDDATE")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("CREATEDTIME")
                        .HasColumnType("time");

                    b.Property<string>("OneSignalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PushToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GUID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            GUID = new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                            CREATEDDATE = new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            CREATEDTIME = new TimeSpan(363919253480),
                            StudentName = "Ali"
                        },
                        new
                        {
                            GUID = new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                            CREATEDDATE = new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            CREATEDTIME = new TimeSpan(363919253491),
                            StudentName = "Ayşe"
                        },
                        new
                        {
                            GUID = new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                            CREATEDDATE = new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            CREATEDTIME = new TimeSpan(363919253494),
                            StudentName = "Ahmet"
                        });
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.StudentHomeworkMV", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HomeworkId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "HomeworkId");

                    b.HasIndex("HomeworkId");

                    b.ToTable("StudentHomeworkMVs");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                            HomeworkId = new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b")
                        },
                        new
                        {
                            StudentId = new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                            HomeworkId = new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3")
                        },
                        new
                        {
                            StudentId = new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                            HomeworkId = new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b")
                        });
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.StudentHomeworkMV", b =>
                {
                    b.HasOne("OneSignalWebApiv1.Entities.Homework", "Homework")
                        .WithMany("StudentHomeworkMVs")
                        .HasForeignKey("HomeworkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OneSignalWebApiv1.Entities.Student", "Student")
                        .WithMany("StudentHomeworkMVs")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Homework");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.Homework", b =>
                {
                    b.Navigation("StudentHomeworkMVs");
                });

            modelBuilder.Entity("OneSignalWebApiv1.Entities.Student", b =>
                {
                    b.Navigation("StudentHomeworkMVs");
                });
#pragma warning restore 612, 618
        }
    }
}
