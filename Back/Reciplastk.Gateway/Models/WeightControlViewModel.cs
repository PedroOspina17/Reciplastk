using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class WeightControlViewModel
    {
        public int? Weightcontrolid {  get; set; }
        public WeightControlProductsViewModel Product { get; set; }
        public WeightControlEmployeeViewModel Employee { get; set; }
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set;}
        public decimal Weight {  get; set; }    
        public int Totalpack {  get; set; }
        public Boolean Isactive { get; set; }
        public Boolean Ispaid { get; set; }


    }
}
