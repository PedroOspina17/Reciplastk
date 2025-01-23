namespace RecuperApp.Domain.Models.Requests
{
    public class CopyCustomerPricesRequest
    {
        public int CustomerFrom { get; set; }
        public int CustomerTo { get; set; }
    }
}
