namespace Reciplastk.Gateway.Models
{
    public class ProductsViewModel
    {
        public int Productid { get; set; }
        public string Shortname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Buyprice { get; set; }
        public int Sellprice { get; set; }
        public int Margin { get; set; }
        public List<ProductsViewModel> SubtypeProductList {  get; set; }
        public bool Issubtype { get; set; }
        public int? Parentid { get; set; }
        

    }
}
