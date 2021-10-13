﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web;

namespace Web.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Web.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("RaceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Web.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan?>("BestTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Web.Racecar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<int>("TopSpeed")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Racecars");
                });

            modelBuilder.Entity("Web.Driver", b =>
                {
                    b.HasOne("Web.Race", null)
                        .WithMany("Participants")
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("Web.Race", b =>
                {
                    b.HasOne("Web.Driver", "Winner")
                        .WithMany("RacesWon")
                        .HasForeignKey("WinnerId");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Web.Racecar", b =>
                {
                    b.HasOne("Web.Driver", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Web.Driver", b =>
                {
                    b.Navigation("RacesWon");
                });

            modelBuilder.Entity("Web.Race", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
