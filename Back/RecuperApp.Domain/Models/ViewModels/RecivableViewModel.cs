namespace RecuperApp.Domain.Models.ViewModels
{
    public class RecivableViewModel
    {
        public int shipmentid { get; set; }
        public int shipmenttype { get; set; }
        public string shipmenttypename { get; set; }
        public string employeename { get; set; }
        public string customername { get; set; }
        public DateTime date { get; set; }
        public double totalprice { get; set; }
        public List<RecivableDetails> details { get; set; }

    }
}
