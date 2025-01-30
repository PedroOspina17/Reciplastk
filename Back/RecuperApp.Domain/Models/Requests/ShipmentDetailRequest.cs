namespace RecuperApp.Domain.Models.Requests
{
    public class ShipmentDetailRequest
    {
        public int ShipmentId { get; set; }
        public int ProductId { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}
