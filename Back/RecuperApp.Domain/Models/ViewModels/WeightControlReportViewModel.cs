namespace RecuperApp.Domain.Models.ViewModels
{
    public class WeightControlReportViewModel
    {
        public int productid { get; set; }
        public int weightcontroldetailid { get; set; }
        public DateTime date { get; set; }
        public string productName { get; set; }
        public string employeeName { get; set; }
        public double weight { get; set; }
        public string type { get; set; }
    }
}
