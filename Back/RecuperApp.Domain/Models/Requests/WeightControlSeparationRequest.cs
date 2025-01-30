using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Models.Requests
{
    public class WeightControlSeparationRequest
    {
        public int? WeightControlId { get; set; }
        public int EmployeeId { get; set; }

        public List<WeightControlSeparationDetailRequest> WeightControlDetails { get; set; }
    }
}