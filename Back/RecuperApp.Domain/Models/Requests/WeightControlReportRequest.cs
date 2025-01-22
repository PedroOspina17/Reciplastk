namespace RecuperApp.Domain.Models.Requests
{
    public class WeightControlReportRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ProductId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? Ispaid { get; set; }
        public int? Type { get; set; }
    }
}
