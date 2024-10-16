﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GermanyEuro2024_LuuQuangHoa;

public partial class GermanyEuro2024DbContext : DbContext
{
    public GermanyEuro2024DbContext()
    {
    }

    public GermanyEuro2024DbContext(DbContextOptions<GermanyEuro2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FootballPlayer> FootballPlayers { get; set; }

    public virtual DbSet<FootballTeam> FootballTeams { get; set; }

    public virtual DbSet<Uefaaccount> Uefaaccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Admin-PC\\HOA;uid=sa;pwd=12345;database=GermanyEuro2024DB;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FootballPlayer>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Football__4A4E74A88F223808");

            entity.ToTable("FootballPlayer");

            entity.Property(e => e.PlayerId)
                .HasMaxLength(30)
                .HasColumnName("PlayerID");
            entity.Property(e => e.Achievements).HasMaxLength(250);
            entity.Property(e => e.Award).HasMaxLength(250);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.FootballTeamId)
                .HasMaxLength(30)
                .HasColumnName("FootballTeamID");
            entity.Property(e => e.OriginCountry).HasMaxLength(100);
            entity.Property(e => e.PlayerName).HasMaxLength(100);

            entity.HasOne(d => d.FootballTeam).WithMany(p => p.FootballPlayers)
                .HasForeignKey(d => d.FootballTeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FootballP__Footb__3C69FB99");
        });

        modelBuilder.Entity<FootballTeam>(entity =>
        {
            entity.HasKey(e => e.FootballTeamId).HasName("PK__Football__B287F27B4BC712FF");

            entity.ToTable("FootballTeam");

            entity.Property(e => e.FootballTeamId)
                .HasMaxLength(30)
                .HasColumnName("FootballTeamID");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.ManagerName).HasMaxLength(100);
            entity.Property(e => e.TeamTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<Uefaaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__UEFAAcco__349DA586A2A92995");

            entity.ToTable("UEFAAccount");

            entity.HasIndex(e => e.AccountEmail, "UQ__UEFAAcco__FC770D33BD42FB4D").IsUnique();

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountDescription).HasMaxLength(240);
            entity.Property(e => e.AccountEmail).HasMaxLength(80);
            entity.Property(e => e.AccountPassword).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
