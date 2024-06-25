using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace beeTechSolutions_API_.Models;

public partial class TechSolutionsDbContext : DbContext
{
    public TechSolutionsDbContext()
    {
    }

    public TechSolutionsDbContext(DbContextOptions<TechSolutionsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gaming_Console> GamingConsoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gaming_Console>(entity =>
        {
            entity.HasKey(e => e.gamingConsole_id).HasName("PK__Gaming_C__E27BE6B172E934EC");

            entity.ToTable("GamingConsole");

            entity.Property(e => e.gamingConsole_id).HasColumnName("gamingConsole_id");
            entity.Property(e => e.gamingConsoleBrand)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("gamingConsoleBrand");
            entity.Property(e => e.price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
