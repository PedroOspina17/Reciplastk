namespace Reciplastk.Gateway.Models
{
    public class ShipmentTypeViewModel
    {
        public int shipmenttypeid {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime updatedate { get; set; }
        public bool isactive { get; set; }

    }
}
