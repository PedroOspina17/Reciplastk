namespace RecuperApp.Domain.Models.Requests
{
    public class WeightControlGrindingRequest
    {
        public int WeightControlId { get; set; }
        public int ProductId { get; set; }
        public int PackageCount { get; set; }
        public double Remainig { get; set; }
    }
}
