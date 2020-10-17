using Microsoft.EntityFrameworkCore;
using NVSDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSDemo.Data
{
    public class NVSContext : DbContext
    {
        public NVSContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Landmark>()
                .Property(b => b.Latitude).HasColumnType("Decimal(8,6)");

            modelBuilder.Entity<Landmark>()
                .Property(b => b.Longitude).HasColumnType("Decimal(9,6)");
        }
        public DbSet<Landmark> Landmarks { get; set; }
    }
}
