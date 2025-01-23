namespace RecuperApp.Domain.Models.ViewModels
{
    public class PayrollConfigViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string employee { get; set; }
        public string product { get; set; }
        public double buyPrice { get; set; }
        public bool isCurrentePrice { get; set; }
    }
}
