using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public class ShipmentTypeSeederConfiguration : IEntityTypeConfiguration<ShipmentType>
    {
        public void Configure(EntityTypeBuilder<ShipmentType> builder)
        {
            builder.HasData
            (new ShipmentType
            {
                Id = 1,
                Name = "Ingreso",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Material que ingresa a la bodega enviado por los proveedores. Compras",
                CreatedBy = "Seeder"
            },
            new ShipmentType
            {
                Id = 2,
                Name = "Salida",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Material que ingresa a la bodega enviado por los proveedores. Ventas",
                CreatedBy = "Seeder"
            }
            );
        }
    }
}
