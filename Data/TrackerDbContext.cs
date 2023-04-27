using Tracker.Models;
using Tracker.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Tracker.Data
{
    public class TrackerDbContext: DbContext
    {
        public DbSet<Seed>? Seeds { get; set; }
        public DbSet<Bed>?  Beds { get; set; }


        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seed>()
            .HasMany(e => e.Beds)
            .WithMany(e => e.Seeds);

            modelBuilder.Entity<Bed>()
            .HasMany(f => f.Seeds)
            .WithMany(f => f.Beds);
        }
    }
}
