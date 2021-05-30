using Cotecna.Inspections.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotecna.Inspections.Data
{
    public class InspectionsContext : DbContext
    {
        public InspectionsContext(DbContextOptions<InspectionsContext> options)
            : base(options)
        {
        }

        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectorInfo> Inspectors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inspection>(entity =>
            {
                entity.HasOne(e => e.Inspector)
                    .WithMany(e => e.Inspections)
                    .HasForeignKey(d => d.InspectorId);
            });
        }
    }
}
