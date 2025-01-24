using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;

namespace RecuperApp.Domain.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> GetByUserName(string name);
        Task<Employee> Create(EmployeeRequest employee);
        Task<Employee> Update(EmployeeRequest employee);
        Task<Employee> Delete(int id);
        Task<Employee> ValidateLogIn(string userName, string password);
    }
}
