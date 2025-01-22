namespace RecuperApp.Domain.Models.Requests
{
    public class PayrollConfigRequest
    {
        public int productid { get; set; }
        public int employeeid { get; set; }
        public double priceperkilo { get; set; }
        public bool? showAll { get; set; }
    }
}
