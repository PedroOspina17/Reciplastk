using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Repositories.Seeders;

namespace RecuperApp.Domain.Repositories;

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

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PayrollConfig> PayrollConfigs { get; set; }

    public virtual DbSet<PriceType> PriceTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<Remaining> Remainings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }

    public virtual DbSet<ShipmentType> ShipmentTypes { get; set; }

    public virtual DbSet<WeightControl> WeightControls { get; set; }

    public virtual DbSet<WeightControlDetail> WeightControlDetails { get; set; }

    public virtual DbSet<WeightControlType> WeightControlTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureApplicationSeeders();
    }

}
