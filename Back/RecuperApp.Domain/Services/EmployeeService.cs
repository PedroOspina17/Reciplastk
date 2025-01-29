using AutoMapper;
using RecuperApp.Common.Exceptions;
using RecuperApp.Common.Helpers;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{
    public class EmployeeService : ApplicationService<Employee, EmployeeRequest>, IEmployeeService
    {

        public EmployeeService(IApplicationRepository<Employee> applicationRepository, IMapper mapper) : base(applicationRepository, mapper)
        {
        }

        public override async Task<List<Employee>> GetAll()
        {
            return await applicationRepository.GetAllAsync(include: ["Role"]);
        }

        public async Task<Employee> GetByUserName(string userName)
        {
            return await applicationRepository.FindByParamAsync(x => x.UserName == userName);
        }

        protected override async Task<bool> ValidateEntity(EmployeeRequest viewModel)
        {
            var result = true;
            var existEmployee = await GetByUserName(viewModel.UserName);
            if (existEmployee != null)
            {
                result = false;
                throw new CustomValidationsException("Ya existe un empleado con este nombre de usuario.");
            }
            return result;
        }
        public async Task<Employee> ValidateLogIn(ValidateUserRequest request)
        {
            //request.Password = Encrypt.EncryptPassword(request.Password); // Todo: Start using encription on passwords.

            var result = await applicationRepository.FindByParamAsync(x => x.UserName.ToLower().Trim() == request.UserName.ToLower().Trim() && x.Password.ToLower().Trim() == request.Password.ToLower().Trim());
            if (result == null)
                throw new CustomValidationsException("El usuario o contraseña son incorrectos, por favor intente nuevamente.", logException: false);
            return result;
        }
    }
}
