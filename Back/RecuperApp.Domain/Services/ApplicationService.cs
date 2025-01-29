using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RecuperApp.Common.Exceptions;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.EntityModels.Base;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{

    public class ApplicationService<EntityType, entityRequestType> : IApplicationService<EntityType, entityRequestType> where EntityType : BaseEntity
    {
        protected readonly IApplicationRepository<EntityType> applicationRepository;
        protected readonly IMapper mapper;



        public ApplicationService(IApplicationRepository<EntityType> applicationRepository, IMapper mapper)
        {
            this.applicationRepository = applicationRepository;
            this.mapper = mapper;
        }
        public virtual async Task<EntityType> GetById(int id)
        {
            var product = await this.applicationRepository.FindByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException("No se encontro ningún resultado con el Id especificado.");
            }
            return product;
        }
        public virtual async Task<List<EntityType>> GetAll()
        {
            return await this.applicationRepository.GetAllAsync();
        }
        public virtual async Task<EntityType> Create(entityRequestType entityRequestModel)
        {
            if (await ValidateEntity(entityRequestModel))
            {
                var entityToCreate = mapper.Map<EntityType>(entityRequestModel);
                return await applicationRepository.CreateAsync(entityToCreate);
            }
            return default(EntityType);
        }

        public virtual async Task<EntityType> Update(entityRequestType entityRequestModel)
        {
            var entityModel = mapper.Map<EntityType>(entityRequestModel);
            var modelToUpdate = await GetById(entityModel.Id);
            modelToUpdate = mapper.Map(entityRequestModel, modelToUpdate);
            if (await ValidateEntity(entityRequestModel))
            {
                await applicationRepository.UpdateAsync(modelToUpdate);
            }
            return modelToUpdate;
        }

        public virtual async Task<EntityType> Delete(int id)
        {
            var modelToDelete = await GetById(id);
            await applicationRepository.DeleteAsync(modelToDelete);
            return modelToDelete;

        }
        protected virtual async Task<bool> ValidateEntity(entityRequestType ProductsModel)
        {
            return await Task.FromResult(true);
        }

    }

    public class ApplicationService<EntityType> : ApplicationService<EntityType, EntityType> where EntityType : BaseEntity
    {
        public ApplicationService(IApplicationRepository<EntityType> applicationRepository, IMapper mapper) : base(applicationRepository, mapper) { }
    }
}
