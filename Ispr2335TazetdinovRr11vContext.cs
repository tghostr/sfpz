using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1;

public partial class Ispr2335TazetdinovRr11vContext : DbContext
{
    public Ispr2335TazetdinovRr11vContext()
    {
    }
    private static Ispr2335TazetdinovRr11vContext instance;
    public static Ispr2335TazetdinovRr11vContext init()
    {
        if (instance == null)
            instance = new Ispr2335TazetdinovRr11vContext();
        return instance;
    }

    public Ispr2335TazetdinovRr11vContext(DbContextOptions<Ispr2335TazetdinovRr11vContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<PhoneBrand> PhoneBrands { get; set; }

    public virtual DbSet<SellHiistory> SellHiistories { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("port=3306;database=ISPr23-35_TazetdinovRR_11v;password=ISPr23-35_TazetdinovRR;user id=ISPr23-35_TazetdinovRR;character set=utf8;server=cfif31.ru", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.ClientFirstName)
                .HasMaxLength(64)
                .HasColumnName("Client_FirstName");
            entity.Property(e => e.ClientLastName)
                .HasMaxLength(64)
                .HasColumnName("Client_LastName");
            entity.Property(e => e.ClientPhone).HasColumnName("Client_Phone");
            entity.Property(e => e.CliientMiddleName)
                .HasMaxLength(64)
                .HasColumnName("Cliient_MiddleName");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("PRIMARY");

            entity.HasIndex(e => e.PhoneBrandId, "FK_Product_TypeId_idx");

            entity.Property(e => e.PhoneId).HasColumnName("Phone_Id");
            entity.Property(e => e.PhoneBrandId).HasColumnName("Phone_BrandId");
            entity.Property(e => e.PhoneModel)
                .HasMaxLength(64)
                .HasColumnName("Phone_Model");
            entity.Property(e => e.PhonePrice)
                .HasPrecision(8, 2)
                .HasColumnName("Phone_Price");

            entity.HasOne(d => d.PhoneBrand).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PhoneBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_TypeId");
        });

        modelBuilder.Entity<PhoneBrand>(entity =>
        {
            entity.HasKey(e => e.PhoneBrandId).HasName("PRIMARY");

            entity.ToTable("PhoneBrand");

            entity.Property(e => e.PhoneBrandId).HasColumnName("PhoneBrand_Id");
            entity.Property(e => e.PhoneBrandName)
                .HasMaxLength(64)
                .HasColumnName("PhoneBrand_Name");
        });

        modelBuilder.Entity<SellHiistory>(entity =>
        {
            entity.HasKey(e => e.SellHiistoryId).HasName("PRIMARY");

            entity.ToTable("SellHiistory");

            entity.HasIndex(e => e.SellHiistoryClientId, "FK_SellHiistory_Client_Id_idx");

            entity.HasIndex(e => e.SellHiistoryProductId, "FK_SellHiistory_Product_Id_idx");

            entity.HasIndex(e => e.SellHiistorySellerId, "FK_SellHiistory_Seller_Id_idx");

            entity.Property(e => e.SellHiistoryId)
                .ValueGeneratedNever()
                .HasColumnName("SellHiistory_Id");
            entity.Property(e => e.SellHiistoryClientId).HasColumnName("SellHiistory_Client_Id");
            entity.Property(e => e.SellHiistoryDateTime)
                .HasColumnType("datetime")
                .HasColumnName("SellHiistory_DateTime");
            entity.Property(e => e.SellHiistoryProductId).HasColumnName("SellHiistory_Product_Id");
            entity.Property(e => e.SellHiistorySellerId).HasColumnName("SellHiistory_Seller_Id");

            entity.HasOne(d => d.SellHiistoryClient).WithMany(p => p.SellHiistories)
                .HasForeignKey(d => d.SellHiistoryClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellHiistory_Client_Id");

            entity.HasOne(d => d.SellHiistoryProduct).WithMany(p => p.SellHiistories)
                .HasForeignKey(d => d.SellHiistoryProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellHiistory_Product_Id");

            entity.HasOne(d => d.SellHiistorySeller).WithMany(p => p.SellHiistories)
                .HasForeignKey(d => d.SellHiistorySellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellHiistory_Seller_Id");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PRIMARY");

            entity.Property(e => e.SellerId).HasColumnName("Seller_Id");
            entity.Property(e => e.SellerFirstName)
                .HasMaxLength(64)
                .HasColumnName("Seller_FirstName");
            entity.Property(e => e.SellerLastName)
                .HasMaxLength(64)
                .HasColumnName("Seller_LastName");
            entity.Property(e => e.SellerLogin)
                .HasMaxLength(64)
                .HasColumnName("Seller_Login");
            entity.Property(e => e.SellerMiddleName)
                .HasMaxLength(64)
                .HasColumnName("Seller_MiddleName");
            entity.Property(e => e.SellerPassword)
                .HasMaxLength(64)
                .HasColumnName("Seller_Password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
