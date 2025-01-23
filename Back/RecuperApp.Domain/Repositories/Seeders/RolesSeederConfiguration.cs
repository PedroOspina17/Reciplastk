using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public class RolesSeederConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                RoleId = 1,
                Name = "Admin",
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                CreatedBy = "Seeder"
            }
            );
        }
    }
}
