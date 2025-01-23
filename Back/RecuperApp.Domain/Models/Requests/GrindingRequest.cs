namespace RecuperApp.Domain.Models.Requests
{
    public class GrindingRequest
    {
        public int Weightcontrolid { get; set; }
        public int ProductId { get; set; }
        public int PackageCount { get; set; }
        public double Remainig { get; set; }
    }
}
