using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IWeightControlService : IApplicationService<WeightControl>
    {
        Task<WeightControl> CreateGrinding(WeightControlGrindingRequest model);
        Task<WeightControl> CreateSeparation(WeightControlSeparationRequest model);
        Task<List<WeightControlReportViewModel>> Filter(WeightControlReportRequest viewModel);
        Task<List<GroundProductViewModel>> GetGroundProducts();
        Task<List<RemainigsViewModel>> Remainings(bool ViewAll);
    }
}