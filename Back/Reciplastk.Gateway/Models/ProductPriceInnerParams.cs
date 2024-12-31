namespace Reciplastk.Gateway.Models
{
    public class ProductPriceInnerParams
    {
        public DateTime date { get; set; }
        public string employee { get; set; }
        public string customer { get; set; }
        public Double price { get; set; }
        public Boolean iscurrentprice { get; set; }
        public string product { get; set; }
        public string type { get; set; }
    }
}
