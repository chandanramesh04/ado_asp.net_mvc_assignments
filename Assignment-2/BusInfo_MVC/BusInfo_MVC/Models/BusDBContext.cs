using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusInfo_MVC.Models
{
    public partial class BusDBContext : DbContext
    {
        public BusDBContext()
        {
        }

        public BusDBContext(DbContextOptions<BusDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusInfo> BusInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=chandan\\SQLEXPRESS; Initial Catalog=BusDB; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusInfo>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("PK__BusInfo__6A0F6095C2457C84");

                entity.ToTable("BusInfo");

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.BoardingPoint)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TravelDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
