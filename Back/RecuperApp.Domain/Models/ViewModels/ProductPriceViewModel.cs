namespace RecuperApp.Domain.Models.ViewModels
{
    public class ProductPriceViewModel
    {
        public DateTime date { get; set; }
        public string employee { get; set; }
        public string customer { get; set; }
        public double price { get; set; }
        public bool iscurrentprice { get; set; }
        public string product { get; set; }
        public string type { get; set; }
    }
}
