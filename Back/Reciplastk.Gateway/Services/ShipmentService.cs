using Reciplastk.Gateway.DataAccess;

namespace Reciplastk.Gateway.Services
{
    public class ShipmentService
    {
        private readonly ReciplastkContext db;
        private ShipmentService(ReciplastkContext db)
        {
            this.db = db;
        }
    }
}
