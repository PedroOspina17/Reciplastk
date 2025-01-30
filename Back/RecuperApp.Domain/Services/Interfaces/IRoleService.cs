using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IRoleService : IApplicationService<Role, RoleViewModel>
    {
        Task<Role> GetByName(string name);
    }
}
