namespace RecuperApp.Domain.Models.ViewModels
{
    public class ShipmentDetailViewModel
    {
        public int shipmentid { get; set; }
        public int productid { get; set; }
        public double weight { get; set; }
        public double price { get; set; }
        public double subtotal { get; set; }
        public DateTime Shipmentdate { get; set; }
    }
}
