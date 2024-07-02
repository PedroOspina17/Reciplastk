using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class ShipmentViewModel
    {
        public int? shipmentid { get; set; }
        public Customer customer { get; set; }
        public Employee employee { get; set; }
        public Shipmenttype shipmenttype { get; set; }
        public DateTime shipmentstartdate { get; set; }
        public DateTime shipmentstartend { get; set; }
        public Boolean ispaid { get; set; }
        public Boolean iscomplete { get; set; }
        public Boolean isactive { get; set; }
    }
}
