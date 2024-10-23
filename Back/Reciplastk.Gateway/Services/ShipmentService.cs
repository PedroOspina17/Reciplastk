using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using System.IO.Compression;

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
        private Shipment GetByid(int shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Shipmentid == shipmentid && x.Isactive).FirstOrDefault();
            return shipment;
        }
       
        public HttpResponseModel Create(ShipmentViewModel shipmentViewModel)
        {
            var response = new HttpResponseModel();    
            
                var newShipment = new Shipment();
                newShipment.Customerid = shipmentViewModel.customerid;
                newShipment.Employeeid = 29; // to do: obtener de usuario logeado
                newShipment.Shipmenttypeid = shipmentViewModel.shipmenttypeid;
                newShipment.Shipmentstartdate = DateTime.Now;
                newShipment.Shipmentenddate = DateTime.Now;
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

        public HttpResponseModel Filter(ShipmentReportParamsViewModel viewModel)
        {
            var response = new HttpResponseModel();
            var query = db.Shipmentdetails.Where(p=> p.Shipment.Isactive == true);
            if (viewModel.StartDate != null) {
                query = query.Where(p => p.Shipment.Shipmentstartdate >= viewModel.StartDate);
            }
            if (viewModel.EndDate != null) {
                query = query.Where(p => p.Shipment.Shipmentstartdate <= viewModel.EndDate);
            }
            if (viewModel.EmployeeId != null && viewModel.EmployeeId != -1) { 
                query = query.Where(p=> p.Shipment.Employeeid == viewModel.EmployeeId);
            }
            if (viewModel.ProductId != null && viewModel.ProductId != -1) {
                query = query.Where(p => p.Productid == viewModel.ProductId);
            }
            if (viewModel.IsPaid != null) {
                query = query.Where(p => p.Shipment.Ispaid == viewModel.IsPaid);
            }
            if (viewModel.Type != null && viewModel.Type != -1) {
                query = query.Where(p => p.Shipment.Shipmenttypeid == viewModel.Type);
            }
            var result = query.Select(p => new ShipmentReports
            {
                ProductName = p.Product.Name,
                EmployeeName = p.Shipment.Employee.Name,
                Weight = p.Weight,
                Type = p.Shipment.Shipmenttype.Name,
            });
            response.Data = result;
            return response;
        }
    }
}
