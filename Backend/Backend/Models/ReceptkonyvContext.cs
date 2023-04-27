using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class ReceptkonyvContext : DbContext
{
    public ReceptkonyvContext()
    {
    }

    public ReceptkonyvContext(DbContextOptions<ReceptkonyvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategorium> Kategoria { get; set; }

    public virtual DbSet<Recept> Recepts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=receptkonyv;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kategori__3213E83FDF7D555F");

            entity.ToTable("kategoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Recept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recept__3213E83F8E7CE522");

            entity.ToTable("recept");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KatId).HasColumnName("kat_id");
            entity.Property(e => e.KepEleresiUt)
                .IsUnicode(false)
                .HasColumnName("kep_eleresi_ut");
            entity.Property(e => e.Leiras)
                .IsUnicode(false)
                .HasColumnName("leiras");
            entity.Property(e => e.Nev)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nev");

            entity.HasOne(d => d.Kat).WithMany(p => p.Recepts)
                .HasForeignKey(d => d.KatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recept__kat_id__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
