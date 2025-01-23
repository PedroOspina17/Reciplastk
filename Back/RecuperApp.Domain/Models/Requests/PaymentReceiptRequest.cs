namespace RecuperApp.Domain.Models.Requests
{
    public class PaymentReceiptRequest
    {
        public string employeeName { get; set; }
        public int employeeId { get; set; }
        public string date { get; set; }
        public int totalWeight { get; set; }
        public int totalToPay { get; set; }
        public List<PaymentReceiptDetailRequest> products { get; set; }
    }
}
