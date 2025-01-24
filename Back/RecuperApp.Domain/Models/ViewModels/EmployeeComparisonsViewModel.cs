namespace RecuperApp.Domain.Models.ViewModels
{
    public class EmployeeComparisonsViewModel
    {
        public int EmployeeId { get; set; }
        public string Label { get; set; }
        public List<double> Data { get; set; }
    }
}
