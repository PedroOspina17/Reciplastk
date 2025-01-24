namespace RecuperApp.Domain.Models.ViewModels
{
    public class RecivableViewModel
    {
        public int ShipmentId { get; set; }
        public int ShipmentType { get; set; }
        public string ShipmentTypeName { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public List<RecivableDetails> Details { get; set; }

    }
}
