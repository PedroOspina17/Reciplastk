using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int? id);
        Task<Role> GetRoleByName(string name);
        Task<Role> AddRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task DeleteRole(Role role);
    }
}
