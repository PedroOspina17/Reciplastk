using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class KpiService
    {
        private readonly ReciplastkContext db;

        public KpiService(ReciplastkContext db)
        {
            this.db = db;
        }

        public double GetSeparationSummary(bool isYearly, int month, int year)
        {
            // ToDo: Replace with enums once the code is merged. 
            var query = db.WeightControlDetails
                .Where(p=> p.WeightControl.WeightControlTypeId == 1 && p.WeightControl.CreatedDate.Year == year && (isYearly || p.WeightControl.CreatedDate.Month == month))
                .Sum(p=> p.Weight);
            return query;
        }
        public double GetGrindingSummary(bool isYearly, int month, int year)
        {
            var query = db.WeightControlDetails
                .Where(p => p.WeightControl.WeightControlTypeId == 2 && p.WeightControl.CreatedDate.Year == year && (isYearly || p.WeightControl.CreatedDate.Month == month))
                .Sum(p => p.Weight);
            return query;
        }

        public double GetShippingSummary(bool isYearly, int month, int year)
        {
            var query = db.ShipmentDetails
                .Where(p => p.Shipment.ShipmenttypeId == 2 && p.Shipment.CreatedDate.Year == year && (isYearly || p.Shipment.CreatedDate.Month == month))
                .Sum(p => p.Weight);
            return query;
        }
        public double GetBillingSummary(bool isYearly, int month, int year)
        {
            var query = db.Shipments
                .Where(p => p.ShipmenttypeId == 2 && p.CreatedDate.Year == year && (isYearly || p.CreatedDate.Month == month))
                //.Sum(p => p.totalPrice); //ToDo: Uncomment when merging the code.
                .Sum(p=> 5000);
            return query;
        }

        public double GetShipmentGoal(bool isYearly, int month, int year)
        {
            return 1500; // ToDo: Change to goals configuraion search, in the future.
        }

        public double GetBillingGoal(bool isYearly, int month, int year)
        {
            return 15000000; // ToDo: Change to goals configuraion search, in the future.
        }
    }
}
