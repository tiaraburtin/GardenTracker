using Tracker.Models;
using Tracker.Controllers;
using 

namespace Tracker.Data
{
    public class TrackerDbContext
    {
        public DbSet<Seed>? Seeds { get; set; }
        public DbSet<Bed>?  Beds { get; set; }

        public DbSet<HardiZone>? HardiZones { get; set; }   

        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seed>()
            .HasMany(e => e.Beds);

            modelBuilder.Entity<Bed>()
            .HasMany(f => f.Seeds);
        }

    }
}
