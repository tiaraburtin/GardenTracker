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
        public DbSet<Seed>? Seeds { get; set; }
        public DbSet<Bed>?  Beds { get; set; }

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

            modelBuilder.Entity<Bed>()
            .HasMany(f => f.Seeds)
            .WithMany(f => f.Beds)
            .UsingEntity(j => j.ToTable("BedSeed"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
