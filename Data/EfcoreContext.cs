using System;
using System.Collections.Generic;
using EFcore.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EFcore.Data;

public partial class EfcoreContext : DbContext
{
    public EfcoreContext()
    {
    }

    public EfcoreContext(DbContextOptions<EfcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:DefaultConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("characters");

            entity.HasIndex(e => e.GameId, "GameId");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Game).WithMany(p => p.Characters)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("characters_ibfk_1");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("games");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
