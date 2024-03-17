using System;
using System.Collections.Generic;
using AgencyDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace AgencyInfrastructure;

public partial class DbagencyContext : DbContext
{
    public DbagencyContext()
    {
    }

    public DbagencyContext(DbContextOptions<DbagencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyType> PropertyTypes { get; set; }

    public virtual DbSet<Transaction1> Transaction1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q1C21MO\\SQLEXPRESS01; Database=DBAgency; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__CAA247C8AADF4F3A");

            entity.ToTable("Address");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("street");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Address__city_id__4D94879B");
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agent__2C05379E5D6649AD");

            entity.ToTable("Agent");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__031491A826EF4E40");

            entity.ToTable("City");

            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city_name");
            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__City__country_id__4AB81AF0");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__BF21A424C18415C4");

            entity.ToTable("Client");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__F8D66423C169B463");

            entity.ToTable("Contract");

            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Agent).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK__Contract__agent___59FA5E80");

            entity.HasOne(d => d.Client).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Contract__client__59063A47");

            entity.HasOne(d => d.Property).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__Contract__proper__5812160E");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__7E8CD055E948FDE1");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__ED1FC9EA316F62FF");

            entity.ToTable("Payment");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Payments)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__Payment__transac__6383C8BA");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Property__735BA4631DE714EC");

            entity.ToTable("Property");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");
            entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.PropertyTypeId).HasColumnName("property_type_id");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Address).WithMany(p => p.Properties)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Property__addres__5535A963");

            entity.HasOne(d => d.Agent).WithMany(p => p.Properties)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK__Property__agent___5441852A");

            entity.HasOne(d => d.PropertyType).WithMany(p => p.Properties)
                .HasForeignKey(d => d.PropertyTypeId)
                .HasConstraintName("FK__Property__proper__534D60F1");
        });

        modelBuilder.Entity<PropertyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Property__2E6FBFAB231DC022");

            entity.ToTable("PropertyType");

            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Transaction1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__85C600AF995A493E");

            entity.ToTable("Transaction1");

            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");

            entity.HasOne(d => d.Agent).WithMany(p => p.Transaction1s)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK__Transacti__agent__5FB337D6");

            entity.HasOne(d => d.Client).WithMany(p => p.Transaction1s)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Transacti__clien__5EBF139D");

            entity.HasOne(d => d.Contract).WithMany(p => p.Transaction1s)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__Transacti__contr__60A75C0F");

            entity.HasOne(d => d.Property).WithMany(p => p.Transaction1s)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__Transacti__prope__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
