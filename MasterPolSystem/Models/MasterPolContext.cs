using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterPolSystem.Models;

public partial class MasterPolContext : DbContext
{
    public MasterPolContext()
    {
    }

    public MasterPolContext(DbContextOptions<MasterPolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPartner> ProductPartners { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MasterPol;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IdPartner).HasName("partner_pkey");

            entity.ToTable("partner");

            entity.Property(e => e.IdPartner)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_partner");
            entity.Property(e => e.DirectorFullName)
                .HasMaxLength(100)
                .HasColumnName("director_full_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdPartnerType).HasColumnName("id_partner_type");
            entity.Property(e => e.Inn)
                .HasMaxLength(20)
                .HasColumnName("inn");
            entity.Property(e => e.LegalAddress)
                .HasMaxLength(100)
                .HasColumnName("legal_address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdPartnerTypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdPartnerType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_id_partner_type_fkey");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.IdPartnerType).HasName("partner_type_pkey");

            entity.ToTable("partner_type");

            entity.Property(e => e.IdPartnerType)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_partner_type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.IdProduct)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_product");
            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.IdProductType).HasColumnName("id_product_type");
            entity.Property(e => e.MinCostForPartner).HasColumnName("min_cost_for_partner");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_id_product_type_fkey");
        });

        modelBuilder.Entity<ProductPartner>(entity =>
        {
            entity.HasKey(e => e.IdProductPartner).HasName("product_partner_pkey");

            entity.ToTable("product_partner");

            entity.Property(e => e.IdProductPartner)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_product_partner");
            entity.Property(e => e.IdPartner).HasColumnName("id_partner");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.SaleDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sale_date");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.ProductPartners)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_partner_id_partner_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductPartners)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_partner_id_product_fkey");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdProductType).HasName("product_type_pkey");

            entity.ToTable("product_type");

            entity.Property(e => e.IdProductType)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_product_type");
            entity.Property(e => e.Coefficient).HasColumnName("coefficient");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
