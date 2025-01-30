using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IShipmentTypeService : IApplicationService<ShipmentType, ShipmentTypeRequest>
    {
        Task<ShipmentType> GetByName(string shipmenttypeName);
    }
}