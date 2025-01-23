using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Models.EntityModels;
using AutoMapper;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Common.Exceptions;

namespace RecuperApp.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<Role> repository;
        private readonly IMapper mapper;

        public RoleService(IBaseRepository<Role> repository, IMapper mapper)
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
            var existRole = await repository.GetByParam(x => x.RoleId == id);

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
            return await repository.GetByParam(x => x.Name == name);
        }


        public async Task<Role> Create(RoleViewModel roleViewModel)
        {
            var existRole = await GetByName(roleViewModel.Name);
            if (existRole == null)
            {
                var role = mapper.Map<Role>(roleViewModel);
                return await repository.CreateAsync(role);
            }
            else
            {
                throw new CustomValidationsException("Ya existe un rol con este nombre.");
            }

        }

        public async Task<Role> Update(RoleViewModel roleViewModel)
        {
            var role = await GetById(roleViewModel.Roleid ?? 0);
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
