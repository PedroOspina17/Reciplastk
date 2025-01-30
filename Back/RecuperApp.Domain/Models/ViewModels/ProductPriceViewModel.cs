namespace RecuperApp.Domain.Models.ViewModels
{
    public class ProductPriceViewModel
    {
        public DateTime Date { get; set; }
        public string Employee { get; set; }
        public string Customer { get; set; }
        public double Price { get; set; }
        public bool IsCurrentPrice { get; set; }
        public string Product { get; set; }
        public string Type { get; set; }
    }
}
