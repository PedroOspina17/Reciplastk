using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
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
            var query = db.Weightcontroldetails
                .Where(p=> p.Weightcontrol.Weightcontroltypeid == 1 && p.Weightcontrol.Creationdate.Year == year && (isYearly || p.Weightcontrol.Creationdate.Month == month))
                .Sum(p=> p.Weight);
            return query;
        }
        public double GetGrindingSummary(bool isYearly, int month, int year)
        {
            var query = db.Weightcontroldetails
                .Where(p => p.Weightcontrol.Weightcontroltypeid == 2 && p.Weightcontrol.Creationdate.Year == year && (isYearly || p.Weightcontrol.Creationdate.Month == month))
                .Sum(p => p.Weight);
            return query;
        }

        public double GetShippingSummary(bool isYearly, int month, int year)
        {
            var query = db.Shipmentdetails
                .Where(p => p.Shipment.Shipmenttypeid == 2 && p.Shipment.Creationdate.Year == year && (isYearly || p.Shipment.Creationdate.Month == month))
                .Sum(p => p.Weight);
            return query;
        }
        public double GetBillingSummary(bool isYearly, int month, int year)
        {
            var query = db.Shipments
                .Where(p => p.Shipmenttypeid == 2 && p.Creationdate.Year == year && (isYearly || p.Creationdate.Month == month))
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
