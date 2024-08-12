namespace Reciplastk.Gateway.Models
{
    public class ProductsViewModel
    {
        public int? ProductId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int Margin { get; set; }
        public List<ProductsViewModel> SubtypeProductList {  get; set; }
        public bool IsSubtype { get; set; }
        public int ParentId { get; set; }

    }
}
