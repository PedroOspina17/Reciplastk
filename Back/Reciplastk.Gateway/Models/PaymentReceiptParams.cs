namespace Reciplastk.Gateway.Models
{
    public class PaymentReceiptParams
    {
        public string employeeName { get; set; }
        public int employeeId { get; set; }
        public string date { get; set; }
        public int totalWeight { get; set; }
        public int totalToPay { get; set; }
        public List<PaymentReceiptParamsDetail> products { get; set; }
    }
}
