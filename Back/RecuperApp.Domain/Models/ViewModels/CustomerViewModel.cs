namespace RecuperApp.Domain.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int? CustomerId { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Cell { get; set; } = "Sin numero";
        public bool? NeedsPickup { get; set; }
        public DateTime? ClientSince { get; set; }
    }
}
