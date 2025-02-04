namespace RecuperApp.Domain.Models.ViewModels
{
    public class PayrollConfigViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string Employee { get; set; }
        public string Product { get; set; }
        public double PricePerKilo { get; set; }
        public bool IsCurrentePrice { get; set; }
    }
}
