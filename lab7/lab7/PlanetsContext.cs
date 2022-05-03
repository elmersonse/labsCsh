using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab7
{
    public partial class PlanetsContext : DbContext
    {
        public PlanetsContext()
        {
        }

        public PlanetsContext(DbContextOptions<PlanetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Galaxy> Galaxies { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Planet> Planets { get; set; } = null!;
        public virtual DbSet<Satellite> Satellites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Planets;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_CI_AS");

            modelBuilder.Entity<Galaxy>(entity =>
            {
                entity.ToTable("Galaxy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.ToTable("Planet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoreTemperature).HasColumnName("Core_temperature");

                entity.Property(e => e.GalaxyId).HasColumnName("Galaxy_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Galaxy)
                    .WithMany(p => p.Planets)
                    .HasForeignKey(d => d.GalaxyId)
                    .HasConstraintName("FK_Planet_Galaxy");
            });

            modelBuilder.Entity<Satellite>(entity =>
            {
                entity.ToTable("Satellite");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PlanetId).HasColumnName("Planet_id");

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.Satellites)
                    .HasForeignKey(d => d.PlanetId)
                    .HasConstraintName("FK_Satellite_Planet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
