using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Models.Requests
{
    public class ShipmentRequest
    {
        public int? shipmentid { get; set; }
        //public Customer customer { get; set; }
        //public Employee employee { get; set; }
        //public Shipmenttype shipmenttype { get; set; }
        public int customerid { get; set; }
        public int employeeid { get; set; }
        public int shipmenttypeid { get; set; }
        public double totalprice { get; set; }
        public DateTime shipmentstartdate { get; set; }
        public DateTime shipmentenddate { get; set; }
        public bool ispaid { get; set; }
        public bool iscomplete { get; set; }
        public bool isactive { get; set; }
        public List<ShipmentDetailViewModel> details { get; set; }
    }
}
