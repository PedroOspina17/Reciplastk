using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public class EmployeeSeederConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(new Employee
            {
                EmployeeId = 1,
                Name = "Super",
                LastName = "Admin",
                DateOfBirth = DateTime.Parse("01/22/2025 10:45:45"),
                DateOfJoin = DateTime.Parse("01/22/2025 10:45:45"),
                DocumentNumber = "1234",
                UserName = "Admin",
                Password = "Admin123",
                RoleId = 1,
                CreatedDate = DateTime.Parse("01/22/2025 10:45:45"),
                IsActive = true,
                CreatedBy = "Seeder"
            }
            );
        }
    }
}
