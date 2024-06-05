using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public partial class PhotoGalleryContext : DbContext
{
    public PhotoGalleryContext()
    {
    }

    public PhotoGalleryContext(DbContextOptions<PhotoGalleryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=srv2\\PUPILS;Initial Catalog=PhotoGallery;Trusted_Connection=True;TrustServerCertificate=True");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("CATEGORIES");

            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.OrderDate).HasColumnName("ORDER_DATE");
            entity.Property(e => e.OrderSum).HasColumnName("ORDER_SUM");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__USER_ID__44FF419A");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("ORDER_ITEM");

            entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Quaninty).HasColumnName("QUANINTY");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDER_ITE__ORDER__47DBAE45");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDER_ITE__PRODU__46E78A0C");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Picture)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("PICTURE");
            entity.Property(e => e.Price).HasColumnName("PRICE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("PRODUCT_NAME");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__PRODUCTS__CATEGO__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
