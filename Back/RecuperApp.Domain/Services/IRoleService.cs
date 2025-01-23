using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();
        Task<Role> GetById(int id);
        Task<Role> GetByName(string name);
        Task<Role> Create(RoleViewModel role);
        Task<Role> Update(RoleViewModel role);
        Task<Role> Delete(int id);
    }
}
