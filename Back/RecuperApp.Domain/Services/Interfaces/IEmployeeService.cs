using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IEmployeeService : IApplicationService<Employee, EmployeeRequest>
    {
        Task<Employee> GetByUserName(string name);
        Task<Employee> ValidateLogIn(ValidateUserRequest request);
    }
}
