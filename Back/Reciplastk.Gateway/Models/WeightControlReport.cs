namespace Reciplastk.Gateway.Models
{
    public class WeightControlReport
    {
        public int productid { get; set; }
        public int weightcontroldetailid { get; set; }
        public DateTime date { get; set; }
        public string productName { get; set; }
        public string employeeName { get; set; }
        public double weight { get; set; } 
        public string type { get; set; }
    }
}
