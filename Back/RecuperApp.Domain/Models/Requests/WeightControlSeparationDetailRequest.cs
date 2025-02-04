namespace RecuperApp.Domain.Models.ViewModels
{
    public class WeightControlSeparationDetailRequest
    {
        public int WeightControlId { get; set; }
        public int ProductId { get; set; }
        public double Weight { get; set; }
    }
}
