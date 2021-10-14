﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web;

namespace Web.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20211014192649_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DriverRace", b =>
                {
                    b.Property<Guid>("ParticipantsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RacesLostId")
                        .HasColumnType("uuid");

                    b.HasKey("ParticipantsId", "RacesLostId");

                    b.HasIndex("RacesLostId");

                    b.ToTable("DriverRace");
                });

            modelBuilder.Entity("Web.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Web.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan?>("BestTime")
                        .HasColumnType("interval");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Web.Racecar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Model")
                        .HasColumnType("integer");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TopSpeed")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Racecars");
                });

            modelBuilder.Entity("DriverRace", b =>
                {
                    b.HasOne("Web.Driver", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Race", null)
                        .WithMany()
                        .HasForeignKey("RacesLostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Web.Driver", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("RacesWon");
                });
#pragma warning restore 612, 618
        }
    }
}