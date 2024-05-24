namespace Reciplastk.Gateway.Models
{
    public class CustomerViewModel
    {
        public int? Id { get; set; }
        public String Nit { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Cell { get; set; }
        public DateTime? Clientsince { get; set; }
        public bool? Needspickup { get; set;}
    }
}
