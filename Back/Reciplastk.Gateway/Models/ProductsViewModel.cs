namespace Reciplastk.Gateway.Models
{
    public class ProductsViewModel
    {
        public int? Productid { get; set; }
        public string Shortname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool Issubtype { get; set; }
        public List<ProductsViewModel> SubtypeProductList {  get; set; }
        
    }
}
