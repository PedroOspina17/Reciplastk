using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class WeightControlViewModel
    {
        public int? Weightcontrolid {  get; set; }

        public int? Employeeid { get; set; }
        public int? Productid { get; set; }
        public Product Product { get; set; }
        public Employee Employee { get; set; }
        public int? Alternateid { get; set; }
        public DateTime? Datestart { get; set; }
        public DateTime? Dateend { get; set;}
        public decimal Weight {  get; set; }    
        public int Totalpack {  get; set; }
        public Boolean Isactive { get; set; }
        public Boolean Ispaid { get; set; }


    }
}
