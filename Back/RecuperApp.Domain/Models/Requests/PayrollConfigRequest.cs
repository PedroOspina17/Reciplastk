namespace RecuperApp.Domain.Models.Requests
{
    public class PayrollConfigRequest
    {
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public double PricePerKilo { get; set; }
        public bool? ShowAll { get; set; }
    }
}
