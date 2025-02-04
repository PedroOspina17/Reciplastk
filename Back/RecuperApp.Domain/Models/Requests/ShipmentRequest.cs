namespace RecuperApp.Domain.Models.Requests
{
    public class ShipmentRequest
    {
        public int? ShipmentId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipmentTypeId { get; set; }
        public double TotalPrice { get; set; }
        public List<ShipmentDetailRequest> Details { get; set; }
    }
}
