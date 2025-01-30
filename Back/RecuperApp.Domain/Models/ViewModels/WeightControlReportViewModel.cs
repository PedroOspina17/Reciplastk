namespace RecuperApp.Domain.Models.ViewModels
{
    public class WeightControlReportViewModel
    {
        public int ProductId { get; set; }
        public int WeightControlDetailId { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public string EmployeeName { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
    }
}
