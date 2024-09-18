using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class WeightControlViewModel
    {
        public int? Weightcontrolid { get; set; }
        public int Employeeid { get; set; }
        public int WeightControlTypeId { get; set; } 
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }
        public Boolean Ispaid { get; set; }
        public Boolean Isactive { get; set; }


    }
}