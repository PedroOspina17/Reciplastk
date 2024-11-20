using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
{
    public interface IRolService
    {
        Task<List<Rol>> GetAllRol();
        Task<Rol> GetRolById(int? id);
        Task<Rol> GetRolByName(string name);
        Task<Rol> AddRol(Rol rol);
        Task<Rol> UpdateRol(Rol rol);
        Task DeleteRol(Rol rol);
    }
}
