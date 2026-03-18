using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Application.Infrastructure.Entities;

namespace Application.Infrastructure.Data;

public partial class TaskManagementSystemDbContext : DbContext
{
    public TaskManagementSystemDbContext()
    {
    }

    public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Infrastructure.Entities.Task> tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(" Server=1R-40;Database = TaskManagementSystemDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Infrastructure.Entities.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TASKS__3214EC277EE84406");

            entity.ToTable("TASKS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ModifiedAT");
            entity.Property(e => e.Priority).HasMaxLength(40);
            entity.Property(e => e.Status).HasMaxLength(40);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Assign).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssignId)
                .HasConstraintName("FK__TASKS__ModifiedA__2B3F6F97");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3214EC0722E797AF");

            entity.ToTable("USERS");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ModifiedAT");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
