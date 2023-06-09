﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracker.Data;

#nullable disable

namespace Tracker.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    [Migration("20230501154633_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BedSeed", b =>
                {
                    b.Property<int>("BedsId")
                        .HasColumnType("int");

                    b.Property<int>("SeedsId")
                        .HasColumnType("int");

                    b.HasKey("BedsId", "SeedsId");

                    b.HasIndex("SeedsId");

                    b.ToTable("BedSeed", (string)null);
                });

            modelBuilder.Entity("Tracker.Models.Bed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("Tracker.Models.Seed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePlanted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HardinessZone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Seeds");
                });

            modelBuilder.Entity("BedSeed", b =>
                {
                    b.HasOne("Tracker.Models.Bed", null)
                        .WithMany()
                        .HasForeignKey("BedsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tracker.Models.Seed", null)
                        .WithMany()
                        .HasForeignKey("SeedsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
