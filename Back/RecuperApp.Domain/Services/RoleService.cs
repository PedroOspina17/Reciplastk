using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Models.EntityModels;
using AutoMapper;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Common.Exceptions;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IApplicationRepository<Role> repository;
        private readonly IMapper mapper;

        public RoleService(IApplicationRepository<Role> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public async Task<List<Role>> GetAll()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Role> GetById(int id)
        {
            var existRole = await repository.FindByIdAsync(id);

            if (existRole != null)
            {
                return existRole;
            }
            else
            {
                throw new NotFoundException("No existe un rol con este id.");
            }
        }

        public async Task<Role> GetByName(string name)
        {
            var result = await repository.FindByParamAsync(x => x.Name == name);
            return result;
        }


        public async Task<Role> Create(RoleViewModel roleViewModel)
        {
            await ValidateEntity(roleViewModel);
            var role = mapper.Map<Role>(roleViewModel);
            return await repository.CreateAsync(role);
        }
        public async Task<bool> ValidateEntity(RoleViewModel productsModel)
        {
            var existRole = await GetByName(productsModel.Name);
            if (existRole != null)
            {
                throw new CustomValidationsException("Ya existe un rol con este nombre.");
            }
            return true;
        }

        public async Task<Role> Update(RoleViewModel roleViewModel)
        {
            var role = await GetById(roleViewModel.Id ?? 0);
            role = mapper.Map(roleViewModel, role);
            return await repository.UpdateAsync(role);
        }

        public async Task<Role> Delete(int id)
        {
            var role = await GetById(id);
            await repository.DeleteAsync(role);
            return role;

        }

    }
}
