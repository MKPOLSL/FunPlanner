﻿// <auto-generated />
using System;
using FunPlannerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FunPlannerApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211129143427_define-many-to-many")]
    partial class definemanytomany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FunPlannerShared.Data.Entities.CalendarEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EventRegistration")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLimited")
                        .HasColumnType("bit");

                    b.Property<int?>("Limit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("FunPlannerShared.Data.Entities.EventParticipants", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("FunPlannerShared.Data.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("FunPlannerShared.Data.Entities.CalendarEvent", b =>
                {
                    b.HasOne("FunPlannerShared.Data.Entities.Person", "Creator")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("FunPlannerShared.Data.Entities.EventParticipants", b =>
                {
                    b.HasOne("FunPlannerShared.Data.Entities.CalendarEvent", "CalendarEvent")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FunPlannerShared.Data.Entities.Person", "Person")
                        .WithMany("ParticipatedEvents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CalendarEvent");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("FunPlannerShared.Data.Entities.CalendarEvent", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("FunPlannerShared.Data.Entities.Person", b =>
                {
                    b.Navigation("CreatedEvents");

                    b.Navigation("ParticipatedEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
