namespace Reciplastk.Gateway.Models
{
    public class PayrollConfigViewModel
    {
        public int payrollconfigid { get; set; }
        public int productid { get; set; }
        public int employeeid { get; set; }
        public double priceperkilo { get; set; }
        public bool iscurrentePrice { get; set; }
        public DateTime cerationdate { get; set; }
        public DateTime updatedate { get; set; }
        public bool isactive { get; set; }

    }
}
