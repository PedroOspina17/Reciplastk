namespace RecuperApp.Domain.Models
{
    public static class Enums
    {
        public enum CustomerTypeEnum
        {
            Provider = 1,
            Customer = 2,
        }

        public enum PriceTypeEnum
        {
            Buy = 1,
            Sell = 2,
        }

        public enum ShipmentMovementTypeEnum
        {
            In = 1,
            Out = 2,
        }
        public enum WeightControlTypeTypeEnum
        {
            Separation = 1,
            Grinding = 2,
            Compacted = 3,
        }
    }
}
