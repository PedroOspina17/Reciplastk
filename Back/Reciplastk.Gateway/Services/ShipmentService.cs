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
        public HttpResponseModel GetAll()
        {
            var shipment = db.Shipments.Where(p=> p.Isactive).ToList();  
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = shipment;   
            return response;
        }
        public HttpResponseModel GetById(int shipmentid)
        {
            var shipment = GetById(shipmentid);
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
        private Shipment GetById(int? shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Shipmentid == shipmentid && x.Isactive).FirstOrDefault();
            return shipment;
        }
        public HttpResponseModel Create(ShipmentViewModel shipmentViewModel)
        {
            var response = new HttpResponseModel();
            var shipment = GetById(shipmentViewModel.shipmentid);
            if (shipment == null)
            {
                var newShipment = new Shipment();
                newShipment.Customerid = shipmentViewModel.customerid;
                newShipment.Employeeid = shipmentViewModel.employeeid;
                newShipment.Shipmenttypeid = shipmentViewModel.shipmenttypeid;
                newShipment.Shipmentstartdate = DateTime.Now;
                newShipment.Shipmentenddate = DateTime.Now;
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
        public HttpResponseModel Update(ShipmentViewModel shipmentViewModel)
        {
            var response = new HttpResponseModel();
            var shipment = GetById(shipmentViewModel.shipmentid);
            if (shipment != null) 
            {
                shipment.Customerid = shipmentViewModel.customerid;
                shipment.Employeeid = shipmentViewModel.employeeid;
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
        public HttpResponseModel Delete(int shipmentid)
        {
            var response = new HttpResponseModel();
            var shipment = GetById((int?)shipmentid);
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
