namespace Reciplastk.Gateway.Models
{
    public class PayrollConfigParams
    {
        public DateTime creationdate { get; set; }
        public string employee { get; set;}
        public string product { get; set; }
        public double buyPrice { get; set; }
        public bool isCurrentePrice { get; set; }
    }
}
