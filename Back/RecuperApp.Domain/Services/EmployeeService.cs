using AutoMapper;
using RecuperApp.Common.Exceptions;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> repository;
        private readonly IMapper mapper;

        public EmployeeService(IBaseRepository<Employee> _repository, IMapper mapper)
        {
            repository = _repository;
            this.mapper = mapper;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Employee> GetById(int id)
        {
            var existEmployee = await repository.GetByParam(x => x.EmployeeId == id);

            if (existEmployee != null)
            {
                return existEmployee;
            }
            else
            {
                throw new NotFoundException("No existe un rol con este id.");
            }
        }

        public async Task<Employee> GetByUserName(string userName)
        {
            return await repository.GetByParam(x => x.UserName == userName);
        }

        public async Task<Employee> Create(EmployeeRequest viewModel)
        {
            await ValidateEntity(viewModel);
            var employee = mapper.Map<Employee>(viewModel);
            return await repository.CreateAsync(employee);

        }

        public async Task<Employee> Update(EmployeeRequest viewModel)
        {
            var employee = await GetById(viewModel.Employeeid ?? 0);
            employee = mapper.Map(viewModel, employee);
            return await repository.UpdateAsync(employee);
        }


        public async Task<Employee> Delete(int id)
        {
            var employee = await GetById(id);
            await repository.DeleteAsync(employee);
            return employee;
        }

        protected virtual async Task<bool> ValidateEntity(EmployeeRequest viewModel)
        {
            var result = true;
            var existEmployee = await GetByUserName(viewModel.Name);
            if (existEmployee != null)
            {
                result = false;
                throw new CustomValidationsException("Ya existe un empleado con este nombre de usuario.");
            }
            return result;
        }
        public async Task<Employee> ValidateLogIn(string userName, string password)
        {
            return await repository.GetByParam(x => x.UserName == userName && x.Password == password);
        }
    }
}
