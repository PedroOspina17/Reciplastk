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
        public HttpResponseModel ShowAllShipmentTypes()
        {
            var shipmentType = db.Shipmenttypes.Where(x => x.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = shipmentType;
            return response;
        }
        public HttpResponseModel ShowShipmentType (int shipmenttypeid)
        {
            var response = new HttpResponseModel();
            var shipmentType = FindShipmentById(shipmenttypeid);
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
        private Shipmenttype FindShipmentById(int shipmenttypeid)
        {
            var shipmentType = db.Shipmenttypes.Where(x => x.Shipmenttypeid == shipmenttypeid && x.Isactive == true).FirstOrDefault();
            return shipmentType;
        }
        public HttpResponseModel CreateShipmentType(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = new HttpResponseModel();
            var shipmentType = FindShipmentById(shipmentTypeViewModel.shipmenttypeid);
            if (shipmentType == null)
            {
                var newShipmentType = new Shipmenttype();
                newShipmentType.Shipmenttypeid = shipmentTypeViewModel.shipmenttypeid;
                newShipmentType.Name = shipmentTypeViewModel.name;
                newShipmentType.Description = shipmentTypeViewModel.description;
                newShipmentType.Creationdate = DateTime.Now;
                newShipmentType.Isactive = true;
                db.Shipmenttypes.Add(newShipmentType);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = newShipmentType;
                response.StatusMessage = "El tipo de cargamento se creo exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Ya existe un tipo de cargamento con el id indicado";
            }
            return response;
        }
        public HttpResponseModel EditShipmentType(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = new HttpResponseModel();
            var shipmentType = FindShipmentById(shipmentTypeViewModel.shipmenttypeid);
            if (shipmentType != null)
            {
                shipmentType.Shipmenttypeid = shipmentTypeViewModel.shipmenttypeid;
                shipmentType.Name = shipmentTypeViewModel.name;
                shipmentType.Description = shipmentTypeViewModel.description;
                shipmentType.Updatedate = DateTime.Now;
                shipmentType.Isactive = true;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = shipmentType;
                response.StatusMessage = "El tipo de cargamento se edito exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cargamento con el id indicado";
            }
            return response;
        }
        public HttpResponseModel DeleteShipmentType (int shipmentTypeId)
        {
            var response = new HttpResponseModel();
            var shipmentType = FindShipmentById(shipmentTypeId);
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
