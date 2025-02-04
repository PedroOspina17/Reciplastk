using AutoMapper;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class WeightControlTypeService : ApplicationService<WeightControlType>
    {
        public WeightControlTypeService (IApplicationRepository<WeightControlType> applicationRepository, IMapper mapper) : base(applicationRepository, mapper) { }

       
       
    }
}
