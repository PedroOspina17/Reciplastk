namespace RecuperApp.Domain.Models.Requests
{
    public class PriceTypeRequest
    {
        public int PriceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
