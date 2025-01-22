namespace RecuperApp.Domain.Models.Requests
{
    public class ProductPricesRequest
    {
        public int productpriceid { get; set; }
        public int productid { get; set; }
        public int? customerid { get; set; }
        public int pricetypeid { get; set; }
        public int employeeid { get; set; }
        public double price { get; set; }
    }
}
