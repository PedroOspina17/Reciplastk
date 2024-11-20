using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeById(int? id);
        Task<Employee> GetEmployeeByName(string name);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task<Employee> ValidateUser(string userName, string password);
    }
}
