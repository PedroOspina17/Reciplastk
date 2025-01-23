using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Models.ViewModels
{
    public class ProductsViewModel
    {
        public Product productref { get; set; }
        public int? Productid { get; set; }
        public string Shortname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public double Buyprice { get; set; }
        public double Sellprice { get; set; }
        public List<ProductsViewModel> SubtypeProductList { get; set; } = [];
    }
}
