namespace Reciplastk.Gateway.Models
{
    public class ShipmentDetailViewModel
    {
        public int shipmentid { get; set; }
        public int productid { get; set; }
        public Double weight { get; set; }
        public Double price { get; set; }
        public Double subtotal { get; set; }
        public DateTime Shipmentdate { get; set;}
    }
}
