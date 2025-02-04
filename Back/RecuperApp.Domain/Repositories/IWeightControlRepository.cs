using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Repositories
{
    public interface IWeightControlRepository : IApplicationRepository<WeightControl>
    {
        Task<List<WeightControlReportViewModel>> Filter(WeightControlReportRequest viewModel);
        Task<List<GroundProductViewModel>> GetGroundProducts();
        Task MarkWeightControlDetailsAsPaid(List<int> weightControlDetailIds);
    }
}