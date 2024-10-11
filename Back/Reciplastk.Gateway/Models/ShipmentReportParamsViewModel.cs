namespace Reciplastk.Gateway.Models
{
    public class ShipmentReportParamsViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProductId { get; set; }
        public Boolean? IsPaid { get; set; }
        public int? Type { get; set; }
    }
}
