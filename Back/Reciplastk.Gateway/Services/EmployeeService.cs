using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.DataAccess.Repositories;

namespace Reciplastk.Gateway.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> repository;

        public EmployeeService(IBaseRepository<Employee> _repository)
        {
            repository = _repository;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await repository.CreateAsync(employee);
        }

        public async Task DeleteEmployee(Employee employee)
        {
            await repository.DeleteAsync(employee);
        }

        public async Task<Employee> GetEmployeeById(int? id)
        {
            return await repository.GetByParam(x => x.Employeeid == id);
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await repository.UpdateAsync(employee);
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            return await repository.GetByParam(x => x.Name == name);
        }

        public async Task<Employee> ValidateUser(string userName, string password)
        {
            return await repository.GetByParam(x => x.Username == userName && x.Password == password);
        }
    }
}
