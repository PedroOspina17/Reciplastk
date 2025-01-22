namespace RecuperApp.Domain.Models.Requests
{
    public class CustomerTypeRequest
    {
        public int customerTypeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
