namespace RecuperApp.Domain.Models.Requests
{
    public class ProductPriceFilterRequest
    {
        public int? PriceTypeId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public bool? ShowHistory { get; set; }
    }
}
