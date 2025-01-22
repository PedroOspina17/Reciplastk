using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Models.Requests
{
    public class WeightControlRequest
    {
        public int? Weightcontrolid { get; set; }
        public int Employeeid { get; set; }

        public List<WeightControlDetailViewModel> weightdetail { get; set; }
    }
}