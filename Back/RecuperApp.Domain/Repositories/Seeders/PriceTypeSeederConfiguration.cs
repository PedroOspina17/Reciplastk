using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public class PriceTypeSeederConfiguration : IEntityTypeConfiguration<PriceType>
    {
        public void Configure(EntityTypeBuilder<PriceType> builder)
        {
            builder.HasData
            (new PriceType
            {
                PriceTypeId = 1,
                Name = "Compra",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Precios de compra de los productos. Material que ingresa a la bodega y el valor que se paga a los proveedores.",
                CreatedBy = "Seeder"
            },
            new PriceType
            {
                PriceTypeId = 2,
                Name = "Venta",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Precios de venta de los productos. Material que sale de la bodega y el valor que se le cobra a los clientes.",
                CreatedBy = "Seeder"
            }
            );
        }
    }
}
