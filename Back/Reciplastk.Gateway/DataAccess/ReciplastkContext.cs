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

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Secondarytabletest> Secondarytabletests { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=reciplastk.cty0a2ewmeb5.us-east-1.rds.amazonaws.com;Database=Reciplastk;Username=postgres;Password=Admin123");

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

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Testid).HasName("test_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
