using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public class WeightControlTypeSeederConfiguration : IEntityTypeConfiguration<WeightControlType>
    {
        public void Configure(EntityTypeBuilder<WeightControlType> builder)
        {
            builder.HasData
            (new WeightControlType
            {
                Id = 1,
                Name = "Separacion",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Proceso en el que se separa el material",
                CreatedBy = "Seeder"
            },
            new WeightControlType
            {
                Id = 2,
                Name = "Molido",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Proceso en el que se muelen los materiales separados",
                CreatedBy = "Seeder"
            },
            new WeightControlType
            {
                Id = 3,
                Name = "Compactado",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                Description = "Proceso en el que se compacta los materiales",
                CreatedBy = "Seeder"
            }
            );
        }
    }
}
