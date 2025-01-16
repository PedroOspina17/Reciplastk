using Reciplastk.Gateway.DataAccess.Repositories;
using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<Role> repository;

        public RoleService(IBaseRepository<Role> _repository)
        {
            repository = _repository;
        }

        public async Task<Role> AddRole(Role rol)
        {
            return await repository.CreateAsync(rol);
        }

        public async Task DeleteRole(Role role)
        {
            await repository.DeleteAsync(role);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Role> GetRoleById(int? id)
        {
            return await repository.GetByParam(x => x.Roleid == id);
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await repository.GetByParam(x => x.Name == name);
        }

        public async Task<Role> UpdateRole(Role role)
        {
            return await repository.UpdateAsync(role);
        }
    }
}
