using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecuperApp.Domain.Repositories.Seeders
{
    public static class ModelBuilderSeederConfigurations
    {
        public static void ConfigureApplicationSeeders(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomertTypeSeederConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeSeederConfiguration());
            modelBuilder.ApplyConfiguration(new PriceTypeSeederConfiguration());
            modelBuilder.ApplyConfiguration(new RolesSeederConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentTypeSeederConfiguration());
            modelBuilder.ApplyConfiguration(new WeightControlTypeSeederConfiguration());
        }
    }
}
