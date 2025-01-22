namespace RecuperApp.Domain.Models.Requests
{
    public class ProductPriceFilterRequest
    {
        public int? pricetypeid { get; set; }
        public int? productid { get; set; }
        public int? customerid { get; set; }
        public bool? ShowHistory { get; set; }
    }
}
