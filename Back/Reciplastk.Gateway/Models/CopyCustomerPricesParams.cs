namespace Reciplastk.Gateway.Models
{
    public class CopyCustomerPricesParams
    {
        public DateTime date { get; set; }
        public string product { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public bool iscurrentprice { get; set; }
    }
}
