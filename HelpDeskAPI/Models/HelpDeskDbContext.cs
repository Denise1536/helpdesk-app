using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Models;

public partial class HelpDeskDbContext : DbContext
{
    public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Favorite1)
                .HasDefaultValueSql("('false')")
                .HasColumnName("Favorite");

            entity.HasOne(d => d.IdTicketNavigation).WithMany()
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK__Favorites__IdTic__3B75D760");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Favorites__IdUse__3C69FB99");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__Tickets__4B93C7E79F7F50B4");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.DateClosed).HasColumnType("date");
            entity.Property(e => e.DateOpened).HasColumnType("date");
            entity.Property(e => e.Details).IsUnicode(false);
            entity.Property(e => e.Favorites).HasDefaultValueSql("('false')");
            entity.Property(e => e.LastOpened).HasColumnType("date");
            entity.Property(e => e.Resolution).IsUnicode(false);
            entity.Property(e => e.ResolvedBy)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValueSql("('true')");
            entity.Property(e => e.Title)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__B7C9263866DDA097");

            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasDefaultValueSql("('no-email@example.com')");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
