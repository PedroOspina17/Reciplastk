using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class ShipmentTypeService
    {
       private readonly ReciplastkContext db;
       public ShipmentTypeService(ReciplastkContext db) 
       {
            this.db = db;
       }
        public HttpResponseModel GetAll()
        {
            var shipmentType = db.Shipmenttypes.Where(x => x.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = shipmentType;
            return response;
        }
        public HttpResponseModel GetById (int shipmenttypeid)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmenttypeid);
            if (shipmentType != null)
            {
                response.WasSuccessful = true;
                response.Data = shipmentType;
                response.StatusMessage = "El tipo de cargamento se encontro correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cargamento con el id indicado";
            }
            return response;
        }
        private Shipmenttype GetByid(int shipmenttypeid)
        {
            var shipmentType = db.Shipmenttypes.Where(x => x.Shipmenttypeid == shipmenttypeid && x.Isactive == true).FirstOrDefault();
            return shipmentType;
        }
        public HttpResponseModel Create(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmentTypeViewModel.shipmenttypeid);
            
            var newShipmentType = new Shipmenttype();
            newShipmentType.Name = shipmentTypeViewModel.name;
            newShipmentType.Description = shipmentTypeViewModel.description;
            newShipmentType.Creationdate = DateTime.Now;
            newShipmentType.Isactive = true;
            db.Shipmenttypes.Add(newShipmentType);
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El tipo de cargamento se creo exitosamente";
            return response;
        }
        public HttpResponseModel Update(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmentTypeViewModel.shipmenttypeid);
            if (shipmentType != null)
            {
                shipmentType.Shipmenttypeid = shipmentTypeViewModel.shipmenttypeid;
                shipmentType.Name = shipmentTypeViewModel.name;
                shipmentType.Description = shipmentTypeViewModel.description;
                shipmentType.Updatedate = DateTime.Now;
                shipmentType.Isactive = true;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de cargamento se edito exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cargamento con el id indicado";
            }
            return response;
        }
        public HttpResponseModel Delete (int shipmentTypeId)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmentTypeId);
            if (shipmentType != null)
            {
                shipmentType.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo cargamento se elimino correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo cargamento con el id indicado";

            }
            return response;
        }
    }
}
