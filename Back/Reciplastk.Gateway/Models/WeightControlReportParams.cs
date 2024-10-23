namespace Reciplastk.Gateway.Models
{
    public class WeightControlReportParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ProductId { get; set; }
        public int? EmployeeId { get; set; }
        public Boolean? Ispaid { get; set; }
        public int? Type { get; set; }
    }
}
