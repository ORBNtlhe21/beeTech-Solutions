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

    public virtual DbSet<GamingConsole> GamingConsoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:beetechsolutions.database.windows.net,1433;Initial Catalog=techSolutionsDb;Persist Security Info=False;User ID=oarabile;Password=27388#Orb;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GamingConsole>(entity =>
        {
            entity.HasKey(e => e.GamingConsoleId).HasName("PK__Gaming_C__E27BE6B172E934EC");

            entity.ToTable("Gaming_Console");

            entity.Property(e => e.GamingConsoleId).HasColumnName("gamingConsole_id");
            entity.Property(e => e.GamingConsoleBrand)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("gamingConsoleBrand");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
