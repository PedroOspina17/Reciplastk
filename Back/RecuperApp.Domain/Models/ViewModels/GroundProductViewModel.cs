namespace RecuperApp.Domain.Models.ViewModels
{
    public class GroundProductViewModel
    {
        public int Id { get; set; }
        public int ControlId { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public DateTime DateStart { get; set; }
        public double? Remaining { get; set; }
    }
}

