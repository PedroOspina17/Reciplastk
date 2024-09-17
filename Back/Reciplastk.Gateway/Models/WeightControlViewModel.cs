using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class WeightControlViewModel
    {
        public int? Weightcontrolid {  get; set; }
        public int Employeeid { get; set; } 
        public int WeightControlTypeId { get; set; } 
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Boolean Ispaid { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean Isactive { get; set; }


    }
}
