using Reciplastk.Gateway.DataAccess.Repositories;
using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
{
    public class RolService : IRolService
    {
        private readonly IBaseRepository<Rol> repository;

        public RolService(IBaseRepository<Rol> _repository)
        {
            repository = _repository;
        }

        public async Task<Rol> AddRol(Rol rol)
        {
            return await repository.CreateAsync(rol);
        }

        public async Task DeleteRol(Rol rol)
        {
            await repository.DeleteAsync(rol);
        }

        public async Task<List<Rol>> GetAllRol()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Rol> GetRolById(int? id)
        {
            return await repository.GetByParam(x => x.Rolid == id);
        }

        public async Task<Rol> GetRolByName(string name)
        {
            return await repository.GetByParam(x => x.Name == name);
        }

        public async Task<Rol> UpdateRol(Rol rol)
        {
            return await repository.UpdateAsync(rol);
        }
    }
}
