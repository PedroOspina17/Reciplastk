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

    public virtual DbSet<Customertype> Customertypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Paymentdetail> Paymentdetails { get; set; }

    public virtual DbSet<Payrollconfig> Payrollconfigs { get; set; }

    public virtual DbSet<Pricetype> Pricetypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productprice> Productprices { get; set; }

    public virtual DbSet<Remaining> Remainings { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Shipmentdetail> Shipmentdetails { get; set; }

    public virtual DbSet<Shipmenttype> Shipmenttypes { get; set; }

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

            entity.HasOne(d => d.Customertype).WithMany(p => p.Customers).HasConstraintName("fk_customer_type");
        });

        modelBuilder.Entity<Customertype>(entity =>
        {
            entity.HasKey(e => e.Customertypeid).HasName("customertype_pkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employee_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Employees).HasConstraintName("employee_roleid_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payment_pkey");

            entity.HasOne(d => d.Employe).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_employeid_fkey");
        });

        modelBuilder.Entity<Paymentdetail>(entity =>
        {
            entity.HasKey(e => e.Paymentsdetailid).HasName("paymentdetails_pkey");

            entity.HasOne(d => d.Payment).WithMany(p => p.Paymentdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paymentdetails_paymentid_fkey");

            entity.HasOne(d => d.Weightcontroldetail).WithMany(p => p.Paymentdetails).HasConstraintName("paymentdetails_weightcontroldetailid_fkey");
        });

        modelBuilder.Entity<Payrollconfig>(entity =>
        {
            entity.HasKey(e => e.Payrollconfigid).HasName("payrollconfig_pkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payrollconfigs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payrollconfig_employeeid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Payrollconfigs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payrollconfig_productid_fkey");
        });

        modelBuilder.Entity<Pricetype>(entity =>
        {
            entity.HasKey(e => e.Pricetypeid).HasName("pricetype_pkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("products_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
            entity.Property(e => e.Issubtype).HasDefaultValue(false);
            entity.Property(e => e.Updatedate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("products_parentid_fkey");
        });

        modelBuilder.Entity<Productprice>(entity =>
        {
            entity.HasKey(e => e.Productpriceid).HasName("productprice_pkey");

            entity.Property(e => e.Iscurrentprice).HasDefaultValue(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Productprices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productprice_customerid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Productprices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productprice_employeeid_fkey");

            entity.HasOne(d => d.Pricetype).WithMany(p => p.Productprices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productprice_pricetypeid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Productprices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productprice_productid_fkey");
        });

        modelBuilder.Entity<Remaining>(entity =>
        {
            entity.HasKey(e => e.Remainingid).HasName("remainings_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Remainings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("remainings_productid_fkey");

            entity.HasOne(d => d.Weightcontrol).WithMany(p => p.Remainings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("remainings_weightcontrolid_fkey");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Rolid).HasName("rol_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
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

        modelBuilder.Entity<Weightcontrol>(entity =>
        {
            entity.HasKey(e => e.Weightcontrolid).HasName("weightcontrol_pkey");

            entity.Property(e => e.Creationdate).HasDefaultValueSql("now()");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
            entity.Property(e => e.Ispaid).HasDefaultValue(false);
            entity.Property(e => e.Updatedate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Employee).WithMany(p => p.Weightcontrols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("weightcontrol_employeeid_fkey");

            entity.HasOne(d => d.Weightcontroltype).WithMany(p => p.Weightcontrols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("weightcontrol_weightcontroltypeid_fkey");
        });

        modelBuilder.Entity<Weightcontroldetail>(entity =>
        {
            entity.HasKey(e => e.Weightcontroldetailid).HasName("weightcontroldetail_pkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Weightcontroldetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("weightcontroldetail_productid_fkey");

            entity.HasOne(d => d.Weightcontrol).WithMany(p => p.Weightcontroldetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("weightcontroldetail_weightcontrolid_fkey");
        });

        modelBuilder.Entity<Weightcontroltype>(entity =>
        {
            entity.HasKey(e => e.Weightcontroltypeid).HasName("weightcontroltype_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
