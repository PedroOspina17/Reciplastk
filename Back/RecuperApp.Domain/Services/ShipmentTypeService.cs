using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecuperApp.Common.Exceptions;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{
    public class ShipmentTypeService : ApplicationService<ShipmentType, ShipmentTypeRequest>, IShipmentTypeService
    {
        public ShipmentTypeService(IApplicationRepository<ShipmentType> applicationRepository, IMapper mapper) : base(applicationRepository, mapper) { }

        public async Task<ShipmentType> GetByName(string shipmenttypeName)
        {
            return await applicationRepository.FindByParamAsync(x => x.Name == shipmenttypeName && x.IsActive == true);
        }

        protected override async Task<bool> ValidateEntity(ShipmentTypeRequest productsModel)
        {
            var existRole = await GetByName(productsModel.Name);
            if (existRole != null)
            {
                throw new CustomValidationsException("Ya existe un tipo de envios con este nombre.");
            }
            return true;
        }

    }
}
