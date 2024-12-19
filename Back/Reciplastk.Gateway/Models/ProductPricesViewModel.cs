using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Models
{
    public class ProductPricesViewModel
    {
        public int productpriceid { get; set; }
        public int productid { get; set; }
        public int? customerid { get; set; }
        public int pricetypeid { get; set; }
        public int employeeid { get; set; }
        public Double price { get; set; }
    }
}
