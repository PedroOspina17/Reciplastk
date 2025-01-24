using System.Text.Json.Serialization;
using RecuperApp.Domain.Models.EntityModels;

namespace RecuperApp.Domain.Models.Requests
{
    public class ProductsRequest
    {
        [JsonIgnore]
        public Product ProductRef { get; set; }
        public int? ProductId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public List<ProductsRequest> SubtypeProductList { get; set; } = [];
    }
}
