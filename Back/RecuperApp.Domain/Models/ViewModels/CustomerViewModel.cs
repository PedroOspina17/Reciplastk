namespace RecuperApp.Domain.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int? customerid { get; set; }
        public int customertypeid { get; set; }
        public string customertypename { get; set; }
        public string nit { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string cell { get; set; } = "Sin numero";
        public bool? needspickup { get; set; }
        public DateTime? clientsince { get; set; }
    }
}
