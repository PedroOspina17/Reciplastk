using Reciplastk.Gateway.DataAccess;
using System.Linq;

namespace Reciplastk.Gateway.Services
{
    public class CustumerService
    {
        ReciplastkContext db = new ReciplastkContext();

        public void SaveNit(string nit)
        {
            var customer = db.Customers.Where(x => x.Nit == nit );
        }
        public void SaveName()
        {

        }
        public void SaveLastName()
        {

        }
        public void SaveAdress()
        {

        }
        public void SaveCelphone()
        {

        }
        public void SaveClientSince()
        {

        }
        public void NeedsPickUp()
        {

        }
       
    }
}
