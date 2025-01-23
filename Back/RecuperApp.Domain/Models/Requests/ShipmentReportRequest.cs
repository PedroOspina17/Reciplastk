namespace RecuperApp.Domain.Models.Requests
{
    public class ShipmentReportRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProductId { get; set; }
        public bool? IsPaid { get; set; }
        public int? Type { get; set; }
    }
}
