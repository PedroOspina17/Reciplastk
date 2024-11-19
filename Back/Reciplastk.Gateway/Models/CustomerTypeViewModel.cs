namespace Reciplastk.Gateway.Models
{
    public class CustomerTypeViewModel
    {
        public int customerTypeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime updatedate { get; set; }
        public bool isactive { get; set; }
    }
}
