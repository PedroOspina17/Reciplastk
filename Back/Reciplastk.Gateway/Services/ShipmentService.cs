using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class ShipmentService
    {
        private readonly ReciplastkContext db;
        public ShipmentService(ReciplastkContext db)
        {
            this.db = db;
        }
        public HttpResponseModel ShowAllShipment()
        {
            var shipment = db.Shipments.ToList();  
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = shipment;   
            return response;
        }
        public HttpResponseModel ShowShipment(int shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Shipmentid == shipmentid).FirstOrDefault();
            var response = new HttpResponseModel();
            if (shipment != null)
            {
                response.WasSuccessful = true;  
                response.Data = shipment;
                response.StatusMessage = "El cargamento se encontro correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun cargamento con ese id";
            }
            return response;
        }
        private Shipment FindShipmentById(int? shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Shipmentid == shipmentid).FirstOrDefault();
            return shipment;
        }
        public HttpResponseModel CreateShipment(ShipmentViewModel shipmentViewModel)
        {
            var response = new HttpResponseModel();
            var shipment = FindShipmentById(shipmentViewModel.shipmentid);
            if (shipment == null)
            {
                var newShipment = new Shipment();
                newShipment.Customerid = shipmentViewModel.cutomerid;
                newShipment.Employeeid = shipmentViewModel.employyeid;
                newShipment.Shipmenttypeid = shipmentViewModel.shipmenttypeid;
                newShipment.Shipmentstartdate = DateTime.Now;
                newShipment.Shipmentstartend = DateTime.Now;
                newShipment.Ispaid = shipmentViewModel.ispaid;
                newShipment.Iscomplete = shipmentViewModel.iscomplete;
                newShipment.Isactive = true;
                db.Shipments.Add(newShipment);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = newShipment;
                response.StatusMessage = "El cargamento se creo exitosamnete";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Ya existe otro cargamento con el id indicado";
            }
            return response;
        }
        public HttpResponseModel EditShipment(ShipmentViewModel shipmentViewModel)
        {
            var response = new HttpResponseModel();
            var shipment = FindShipmentById(shipmentViewModel.shipmentid);
            if (shipment != null) 
            {
                shipment.Customerid = shipmentViewModel.cutomerid;
                shipment.Employeeid = shipmentViewModel.employyeid;
                shipment.Shipmenttypeid = shipmentViewModel.shipmenttypeid;
                shipment.Ispaid = shipmentViewModel.ispaid;
                shipment.Iscomplete = shipmentViewModel.iscomplete;
                shipment.Isactive = shipmentViewModel.isactive;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = shipment;
                response.StatusMessage = "El cargamento se edito exitosamnete";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun cargamento con el id indicado";
            }
            return response;
        }
        public HttpResponseModel DeleteShipment(int shipmentid)
        {
            var response = new HttpResponseModel();
            var shipment = FindShipmentById(shipmentid);
            if (shipment != null)
            {
                shipment.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El cargamento se elimino correctamente";
            }else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun cargamento con el id indicado";
            }
            return response;
        }
    }
}
