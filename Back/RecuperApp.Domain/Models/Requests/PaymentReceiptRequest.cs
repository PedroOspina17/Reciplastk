namespace RecuperApp.Domain.Models.Requests
{
    public class PaymentReceiptRequest
    {
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public int TotalWeight { get; set; }
        public int TotalToPay { get; set; }
        public List<PaymentReceiptDetailRequest> Products { get; set; }
    }
}
