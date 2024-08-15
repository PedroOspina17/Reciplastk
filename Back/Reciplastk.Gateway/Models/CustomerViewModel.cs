namespace Reciplastk.Gateway.Models
{
    public class CustomerViewModel
    {
        public int? customerid { get; set; } 
        public String nit { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String address { get; set; }
        public String cell { get; set; } = "Sin numero";
        public bool? needspickup { get; set;}
        public DateTime clientsince { get; set; }   
    }
}
