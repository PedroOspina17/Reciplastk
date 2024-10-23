using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class WeightControlViewModel
    {
        public int? Weightcontrolid { get; set; }
        public int Employeeid { get; set; }

        public List<WeightControlDetailViewModel> weightdetail { get; set;}
    }
}