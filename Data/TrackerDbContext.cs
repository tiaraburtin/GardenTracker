using Tracker.Models;
using Tracker.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Tracker.Data
{
    public class TrackerDbContext: IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Seed> Seeds { get; set; }
        public DbSet<Bed>  Beds { get; set; }
        public DbSet<Water> Waters { get; set; }

        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Seed>()
            //.HasMany(e => e.Beds)
            //.WithMany(e => e.Seeds);
            //.UsingEntity(j => j.ToTable("BedSeed"));
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Seed>(builder =>
            {
                builder.ToTable("Seed");

                builder.HasKey(a => a.Id);

            });

            modelBuilder.Entity<Bed>(builder =>
            {
                builder.ToTable("Bed");

                builder.HasKey(a => a.Id);
            });

            modelBuilder.Entity<Water>(builder =>
            {
                builder.ToTable("Water");

                builder.HasKey(a => a.Id);
            });

            modelBuilder.Entity<SeedWaterBed>(builder =>
            {
                builder.ToTable("SeedWaterBed");

                builder.HasKey(a => new
                {
                    a.BedId,
                    a.SeedId,
                    a.WaterId,
                });

                builder.HasOne(a => a.Seed)
                    .WithMany(a => a.SeedWaterBed)
                    .HasForeignKey(a => a.SeedId);

                builder.HasOne(a => a.Water)
                    .WithMany(a => a.SeedWaterBed)
                    .HasForeignKey(a => a.WaterId);

                builder.HasOne(a => a.Bed)
                    .WithMany(a => a.SeedWaterBed)
                    .HasForeignKey(a => a.BedId);
            });

            // modelBuilder.Entity<Water>()
            // .HasMany(f => f.Seeds)
            // .WithMany(f => f.Waters)
            //  .UsingEntity(j => j.ToTable("WaterSeed"));
            //
            // modelBuilder.Entity<Water>()
            // .HasMany(f => f.Beds)
            // .WithMany(f => f.Waters)
            // .UsingEntity(j => j.ToTable("WaterBed"));

      
            base.OnModelCreating(modelBuilder);



        }
    }
}
