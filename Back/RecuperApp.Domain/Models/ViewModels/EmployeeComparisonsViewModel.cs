namespace RecuperApp.Domain.Models.ViewModels
{
    public class EmployeeComparisonsViewModel
    {
        public int EmployeeId { get; set; }
        public string label { get; set; }
        public List<double> data { get; set; }
    }
}
