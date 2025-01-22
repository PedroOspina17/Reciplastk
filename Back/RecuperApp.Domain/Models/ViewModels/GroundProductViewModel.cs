namespace RecuperApp.Domain.Models.ViewModels
{
    public class GroundProductViewModel
    {
        public int detailId { get; set; }
        public int controlId { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public DateTime DateStart { get; set; }
        public double? Remaining { get; set; }
    }
}

