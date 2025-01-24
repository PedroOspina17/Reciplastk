namespace RecuperApp.Domain.Models.Requests
{
    public class ProductPricesRequest
    {
        public int ProductPriceId { get; set; }
        public int ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int PriceTypeId { get; set; }
        public int EmployeeId { get; set; }
        public double Price { get; set; }
    }
}
