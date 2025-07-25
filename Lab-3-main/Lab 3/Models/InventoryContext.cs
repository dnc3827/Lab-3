﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab_3.Models;

public partial class InventoryContext : DbContext
{
    public InventoryContext()
    {
    }

    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DUY38\\SQLEXPRESS;Database=Inventory;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD245AC957");

            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 0)");

            // 👉 Thêm cấu hình cho OriginalPrice
            entity.Property(e => e.OriginalPrice)
                .HasColumnType("decimal(18, 0)");

            // 👉 Thêm cấu hình cho ImageUrl
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
