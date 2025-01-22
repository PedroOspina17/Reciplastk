using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public class CustomertTypeSeederConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasData
            (new CustomerType
            {
                CustomerTypeId = 1,
                Name = "Proveedor",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Personas a los que les compro material",
                CreatedBy = "Seeder"
            },
            new CustomerType
            {
                CustomerTypeId = 2,
                Name = "Cliente",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Personas a los que les vendo mi material ya procesado",
                CreatedBy = "Seeder"
            }
            );
        }
    }
}
