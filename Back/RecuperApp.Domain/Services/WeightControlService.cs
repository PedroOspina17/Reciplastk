using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;
using static RecuperApp.Domain.Models.Enums;

namespace RecuperApp.Domain.Services
{
    public class WeightControlService : ApplicationService<WeightControl>, IWeightControlService
    {
        private readonly IWeightControlRepository weightControlRepository;
        private readonly IApplicationRepository<Remaining> remainingRepository;

        public WeightControlService(IWeightControlRepository applicationRepository, IApplicationRepository<Remaining> remainingRepository, IMapper mapper) : base(applicationRepository, mapper)
        {
            this.weightControlRepository = applicationRepository;
            this.remainingRepository = remainingRepository;
        }

        public async Task<WeightControl> CreateSeparation(WeightControlSeparationRequest model) // Convert this to Create Converted material. 
        {
            var newWeightControl = new WeightControl
            {
                EmployeeId = model.EmployeeId,
                WeightControlTypeId = WeightControlTypeTypeEnum.Separation.GetHashCode(),
                DateStart = DateTime.Now,
                IsPaid = false
            };

            if (model.WeightControlDetails != null)
            {
                foreach (var i in model.WeightControlDetails)
                {
                    var detail = new WeightControlDetail
                    {
                        ProductId = i.ProductId,
                        Weight = i.Weight
                    };
                    newWeightControl.WeightControlDetails.Add(detail);
                }                
            }
            await weightControlRepository.CreateAsync(newWeightControl);
            return newWeightControl;
        }
        public async Task<WeightControl> CreateGrinding(WeightControlGrindingRequest model) // Convert this to Create processed material. 
        {
            var response = new HttpResponseModel();
            var newWeightControl = new WeightControl
            {
                EmployeeId = 1, // To do: replace with confing value
                WeightControlTypeId = WeightControlTypeTypeEnum.Grinding.GetHashCode(), // To do: replace with confing value
                DateStart = DateTime.Now,
                IsPaid = false
            };

            var detail = new WeightControlDetail
            {
                WeightControl = newWeightControl,
                Weight = model.PackageCount * 25, // To do: replace with confing value
                ProductId = model.ProductId
            };
            newWeightControl.WeightControlDetails.Add(detail);
            await weightControlRepository.CreateAsync(newWeightControl);

            var remainig = new Remaining
            {
                WeightControl = newWeightControl,
                ProductId = model.ProductId,
                Weight = model.Remainig
            };
            await remainingRepository.CreateAsync(remainig);
            return newWeightControl;
        }

        public async Task<List<GroundProductViewModel>> GetGroundProducts()
        {
            return await weightControlRepository.GetGroundProducts();
        }

        public async Task<List<WeightControlReportViewModel>> Filter(WeightControlReportRequest viewModel)
        {
            return await weightControlRepository.Filter(viewModel);

        }

        public async Task<List<RemainigsViewModel>> Remainings(bool ViewAll)
        {
            var response = new HttpResponseModel();
            List<Remaining> query = await remainingRepository.GetAllAsync(include: ["Product"]);
            if (!ViewAll)
            {
                var groupedInfo = query.GroupBy(p => p.ProductId);
                query = groupedInfo.Select(p => p.OrderByDescending(x => x.CreatedDate).FirstOrDefault()).ToList();
            }
            var result = query.OrderByDescending(p => p.CreatedDate).Select(p => new RemainigsViewModel
            {
                ProductName = p.Product.Name,
                Weight = p.Weight,
            }).ToList();
            return result;
        }

    }
}