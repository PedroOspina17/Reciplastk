using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IApplicationService<EntityType, entityRequestType> where EntityType : BaseEntity
    {
        Task<EntityType> Create(entityRequestType entityRequestModel);
        Task<EntityType> Delete(int id);
        Task<List<EntityType>> GetAll();
        Task<EntityType> GetById(int id);
        Task<EntityType> Update(entityRequestType entityRequestModel);
    }

    public interface IApplicationService<EntityType> : IApplicationService<EntityType, EntityType> where EntityType : BaseEntity
    {
    }
}