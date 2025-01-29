using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
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
            var shipment = db.Shipments.Where(x => x.IsActive).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = shipment
            };
            return response;
        }
        public HttpResponseModel GetById(int shipmentid)
        {
            var shipment = Exist(shipmentid);
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
        public HttpResponseModel GetReceivableReceiptInfo(int id)
        {
            var response = new HttpResponseModel();
            var query = db.Shipments.Where(x => x.Id == id).Select(z => new RecivableViewModel
            {
                Id = z.Id,
                ShipmentType = z.ShipmenttypeId,
                ShipmentTypeName = z.Shipmenttype.Name,
                EmployeeName = z.Employee.Name,
                CustomerName = z.Customer.Name,
                Date = z.CreatedDate,
                TotalPrice = z.TotalPrice,
                Details = db.ShipmentDetails.Where(sd=> sd.ShipmentId == z.Id).Select(x => new RecivableDetails
                {
                    ProductName = x.Product.Name,
                    Weight = x.Weight,
                    ProductPrice = x.ProductPrice,
                    Subtotal = x.Subtotal,
                }).ToList()
            }).FirstOrDefault();
            if (query != null)
            {
                response.Data = query;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontraron el material con el id indicado";
            }
            return response;
        }
        private Shipment Exist(int shipmentid)
        {
            var shipment = db.Shipments.Where(x => x.Id == shipmentid && x.IsActive).FirstOrDefault();
            return shipment;
        }
       
        public HttpResponseModel Create(ShipmentRequest shipmentViewModel)
        {
            var response = new HttpResponseModel();

            var newShipment = new Shipment
            {
                CustomerId = shipmentViewModel.CustomerId,
                EmployeeId = 29, // to do: obtener de usuario logeado
                ShipmenttypeId = shipmentViewModel.ShipmentTypeId,
                TotalPrice = shipmentViewModel.TotalPrice,
                ShipmentStartDate = DateTime.Now,
                ShipmentEndDate = DateTime.Now,
                IsPaid = false,
                IsComplete = false,
                IsActive = true
            };
            db.Shipments.Add(newShipment);
                foreach (var i in shipmentViewModel.Details)
                {
                var detail = new ShipmentDetail
                {
                    Shipment = newShipment,
                    ProductId = i.ProductId,
                    Weight = i.Weight,
                    ProductPrice = i.Price,
                    Subtotal = i.Subtotal,
                    ShipmentDate = DateTime.Now
                };
                db.ShipmentDetails.Add(detail);
                }
                db.SaveChanges();
                response.StatusMessage = "El cargamento se creo exitosamnete";
            
            return response;
        }
        
        public HttpResponseModel Delete(int shipmentid)
        {
            var response = new HttpResponseModel();
            var shipment = Exist(shipmentid);
            if (shipment != null)
            {
                shipment.IsActive = false;
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

        public HttpResponseModel Filter(ShipmentReportRequest viewModel)
        {
            var response = new HttpResponseModel();
            var query = db.ShipmentDetails.Where(p=> p.Shipment.IsActive == true);
            if (viewModel.StartDate != null) {
                query = query.Where(p => p.Shipment.ShipmentStartDate >= viewModel.StartDate);
            }
            if (viewModel.EndDate != null) {
                query = query.Where(p => p.Shipment.ShipmentStartDate <= viewModel.EndDate);
            }
            if (viewModel.EmployeeId != null && viewModel.EmployeeId != -1) { 
                query = query.Where(p=> p.Shipment.EmployeeId == viewModel.EmployeeId);
            }
            if (viewModel.ProductId != null && viewModel.ProductId != -1) {
                query = query.Where(p => p.ProductId == viewModel.ProductId);
            }
            if (viewModel.IsPaid != null) {
                query = query.Where(p => p.Shipment.IsPaid == viewModel.IsPaid);
            }
            if (viewModel.Type != null && viewModel.Type != -1) {
                query = query.Where(p => p.Shipment.ShipmenttypeId == viewModel.Type);
            }
            var result = query.Select(p => new ShipmentReportViewModel
            {
                ProductName = p.Product.Name,
                EmployeeName = p.Shipment.Employee.Name,
                Weight = p.Weight,
                Type = p.Shipment.Shipmenttype.Name,
                Date = p.Shipment.CreatedDate,
            });
            response.Data = result;
            return response;
        }
        public HttpResponseModel GetShipmentForPayments(int id)
        {
            var response = new HttpResponseModel();
            var query = db.Shipments.Where(x => x.IsPaid == false && x.ShipmenttypeId == id).Select(z => new RecivableViewModel
            {
                Id = z.Id,
                ShipmentType = z.ShipmenttypeId,
                ShipmentTypeName = z.Shipmenttype.Name,
                EmployeeName = z.Employee.Name,
                CustomerName = z.Customer.Name,
                Date = z.CreatedDate,
                TotalPrice = z.TotalPrice,
                Details = db.ShipmentDetails.Where(sd => sd.ShipmentId == z.Id).Select(x => new RecivableDetails
                {
                    ProductName = x.Product.Name,
                    Weight = x.Weight,
                    ProductPrice = x.ProductPrice,
                    Subtotal = x.Subtotal,
                }).ToList()
            }).ToList();
            if (query != null)
            {
                response.Data = query;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontraron materiales sin pagar";
            }
            return response;
        }
    }
}
