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
            var shipment = db.Shipments.Where(x => x.Isactive).ToList();  
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = shipment;   
            return response;
        }
        public HttpResponseModel GetById(int shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Shipmentid == shipmentid && x.Isactive).FirstOrDefault();
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
        private Shipment GetByid(int shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Shipmentid == shipmentid && x.Isactive).FirstOrDefault();
            return shipment;
        }
        private Shipmentdetail GetDetailById (int? shipmentDetail)
        {
            var detail = db.Shipmentdetails.Where(p => p.Shipmentdetailid == shipmentDetail).FirstOrDefault();
            return detail;
        }
        public HttpResponseModel Create(ShipmentViewModel shipmentViewModel)
        {
            var response = new HttpResponseModel();    
            
                var newShipment = new Shipment();
                newShipment.Customerid = shipmentViewModel.customerid;
                newShipment.Employeeid = 29; // to do: obtener de usuario logeado
                newShipment.Shipmenttypeid = shipmentViewModel.shipmenttypeid;
                newShipment.Shipmentstartdate = DateTime.Now;
                newShipment.Shipmentstartend = DateTime.Now;
                newShipment.Ispaid = false;
                newShipment.Iscomplete = false;
                newShipment.Isactive = true;
                db.Shipments.Add(newShipment);
                foreach (var i in shipmentViewModel.details)
                {
                    var detail = new Shipmentdetail();
                    detail.Shipment = newShipment;
                    detail.Productid = i.productid;
                    detail.Weight = i.weight;
                    detail.Shipmentdate = DateTime.Now;
                    db.Shipmentdetails.Add(detail);
                }
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = newShipment;
                response.StatusMessage = "El cargamento se creo exitosamnete";
            
            return response;
        }
        //public HttpResponseModel Update(ShipmentViewModel shipmentViewModel)
        //{
        //    var response = new HttpResponseModel();
        //    var shipment = GetByid(shipmentViewModel.shipmentid);
            
        //    shipment.Customerid = shipmentViewModel.customerid;
        //    shipment.Employeeid = shipmentViewModel.employyeid;
        //    shipment.Shipmenttypeid = shipmentViewModel.shipmenttypeid;
        //    shipment.Ispaid = shipmentViewModel.ispaid;
        //    shipment.Iscomplete = shipmentViewModel.iscomplete;
        //    shipment.Isactive = shipmentViewModel.isactive;
        //    db.SaveChanges();
        //    response.WasSuccessful = true;
        //    response.Data = shipment;
        //    response.StatusMessage = "El cargamento se edito exitosamnete";
        //    return response;
        //}
        public HttpResponseModel Delete(int shipmentid)
        {
            var response = new HttpResponseModel();
            var shipment = GetByid(shipmentid);
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
