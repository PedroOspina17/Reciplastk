using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

public partial class ReciplastkContext : DbContext
{
    public ReciplastkContext()
    {
    }

    public ReciplastkContext(DbContextOptions<ReciplastkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Remaining> Remainings { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Secondarytabletest> Secondarytabletests { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Shipmentdetail> Shipmentdetails { get; set; }

    public virtual DbSet<Shipmenttype> Shipmenttypes { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Weightcontrol> Weightcontrols { get; set; }

    public virtual DbSet<Weightcontroldetail> Weightcontroldetails { get; set; }

    public virtual DbSet<Weightcontroltype> Weightcontroltypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Reciplastk;Username=postgres;Password=Admin123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.Property(e => e.Createddate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employee_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Employees).HasConstraintName("employee_roleid_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("products_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
            entity.Property(e => e.Issubtype).HasDefaultValue(false);
            entity.Property(e => e.Updatedate).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Remaining>(entity =>
        {
            entity.HasKey(e => e.Remainingid).HasName("remainings_pkey");

            entity.HasOne(d => d.Weightcontrol).WithMany(p => p.Remainings).HasConstraintName("remainings_weightcontrolid_fkey");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Rolid).HasName("rol_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Secondarytabletest>(entity =>
        {
            entity.HasKey(e => e.Secondarytabletestid).HasName("secondarytabletest_pkey");

            entity.Property(e => e.Createddate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);

            entity.HasOne(d => d.Test).WithMany(p => p.Secondarytabletests).HasConstraintName("secondarytabletest_testid_fkey");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.Shipmentid).HasName("shipment_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Customer).WithMany(p => p.Shipments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipment_customerid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Shipments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipment_employeeid_fkey");

            entity.HasOne(d => d.Shipmenttype).WithMany(p => p.Shipments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipment_shipmenttypeid_fkey");
        });

        modelBuilder.Entity<Shipmentdetail>(entity =>
        {
            entity.HasKey(e => e.Shipmentdetailid).HasName("shipmentdetail_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Shipmentdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipmentdetail_productid_fkey");

            entity.HasOne(d => d.Shipment).WithMany(p => p.Shipmentdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipmentdetail_shipmentid_fkey");
        });

        modelBuilder.Entity<Shipmenttype>(entity =>
        {
            entity.HasKey(e => e.Shipmenttypeid).HasName("shipmenttype_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Testid).HasName("test_pkey");
        });

        modelBuilder.Entity<Weightcontrol>(entity =>
        {
            entity.HasKey(e => e.Weightcontrolid).HasName("weightcontrol_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
            entity.Property(e => e.Ispaid).HasDefaultValue(false);
            entity.Property(e => e.Updatedate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Employee).WithMany(p => p.Weightcontrols).HasConstraintName("weightcontrol_employeeid_fkey");

            entity.HasOne(d => d.Weightcontroltype).WithMany(p => p.Weightcontrols).HasConstraintName("weightcontrol_weightcontroltypeid_fkey");
        });

        modelBuilder.Entity<Weightcontroldetail>(entity =>
        {
            entity.HasKey(e => e.Weightcontroldetailid).HasName("weightcontroldetail_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Weightcontroldetails).HasConstraintName("weightcontroldetail_productid_fkey");

            entity.HasOne(d => d.Weightcontrol).WithMany(p => p.Weightcontroldetails).HasConstraintName("weightcontroldetail_weightcontrolid_fkey");
        });

        modelBuilder.Entity<Weightcontroltype>(entity =>
        {
            entity.HasKey(e => e.Weightcontroltypeid).HasName("weightcontroltype_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
