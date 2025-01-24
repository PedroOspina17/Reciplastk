using Microsoft.EntityFrameworkCore;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class WeightControlService
    {

        private readonly ReciplastkContext db;
        public WeightControlService(ReciplastkContext db)
        {
            this.db = db;
        }
        private WeightControl FindById(int id)
        {
            var weightcontrol = db.WeightControls.Where(p => p.IsActive == true && p.WeightControlId == id).FirstOrDefault();
            return weightcontrol;

        }
        public HttpResponseModel GetAll()
        {
            var weightControl = db.WeightControls.Where(p => p.IsActive == true).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = weightControl
            };
            return response;
        }

        public HttpResponseModel GetById(int id)
        {
            var weightcontrol = FindById(id);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro el Registro con el id buscado";
            }
            return response;
        }

        public HttpResponseModel CreateSeparation(WeightControlSeparationRequest model)
        {
            var response = new HttpResponseModel();

            var newWeightControl = new WeightControl
            {
                EmployeeId = model.EmployeeId,
                WeightControlTypeId = 1, // To do: Change to config value.
                DateStart = DateTime.Now,
                IsPaid = false,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            db.WeightControls.Add(newWeightControl);
            foreach (var i in model.WeightDetail)
            {
                var detail = new WeightControlDetail
                {
                    WeightControl = newWeightControl,
                    ProductId = i.ProductId,
                    Weight = i.Weight
                };
                db.WeightControlDetails.Add(detail);
            }
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El dato fue agregado correctamente";
            return response;
        }
        public HttpResponseModel CreateGrinding(WeightControlGrindingRequest model)
        {
            var response = new HttpResponseModel();
            var newWeightControl = new WeightControl
            {
                EmployeeId = 29, // To do: replace with confing value
                WeightControlTypeId = 2, // To do: replace with confing value
                DateStart = DateTime.Now,
                IsPaid = false,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            db.WeightControls.Add(newWeightControl);

            var detail = new WeightControlDetail
            {
                WeightControl = newWeightControl,
                Weight = model.PackageCount * 25, // To do: replace with confing value
                ProductId = model.ProductId
            };
            db.WeightControlDetails.Add(detail);

            var remainig = new Remaining
            {
                WeightControl = newWeightControl,
                ProductId = model.ProductId,
                Weight = model.Remainig,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            db.Remainings.Add(remainig);

            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El dato fue agregado correctamente";
            return response;
        }
        public HttpResponseModel Update(WeightControlSeparationRequest model)
        {
            var weightcontrol = FindById(model.WeightControlId ?? -1);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                weightcontrol.EmployeeId = model.EmployeeId;
                weightcontrol.IsPaid = false;
                weightcontrol.UpdatedDate = DateTime.Now;
                weightcontrol.IsActive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El control de peso indicado no existe";
            }
            return response;
        }

        public HttpResponseModel Delete(int id)
        {
            var weightcontrol = FindById(id);
            var response = new HttpResponseModel();
            if (weightcontrol == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El control de peso no pudo ser eliminado";
            }
            else
            {
                weightcontrol.DateEnd = DateTime.Now;
                weightcontrol.IsActive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            return response;
        }

        public HttpResponseModel GetGroundProducts()
        {
            var response = new HttpResponseModel();
            var query = db.WeightControlDetails
                .Where(w => w.WeightControl.IsActive && w.WeightControl.WeightControlTypeId == 2 && w.WeightControl.DateStart > DateTime.Today && w.WeightControl.DateStart < DateTime.Today.AddDays(1))
                .Select(w => new GroundProductViewModel()
                {
                    DetailId = w.WeightControlDetailId,
                    ControlId = w.WeightControlId,
                    Weight = w.Weight,
                    ProductName = w.Product.Name,
                    DateStart = w.WeightControl.DateStart,
                    Remaining = db.Remainings.Where(r => r.WeightControlId == w.WeightControlId).FirstOrDefault().Weight,
                })
            .OrderByDescending(w => w.DetailId)
            .ToList();

            response.WasSuccessful = true;
            response.Data = query;
            return response;
        }
       
        public HttpResponseModel Filter(WeightControlReportRequest viewModel)
        {
            var response = new HttpResponseModel();
            var query = db.WeightControlDetails.Where(p => p.WeightControl.IsActive == true);
            if (viewModel.ProductId != null && viewModel.ProductId != -1)
            {
                query = query.Where(p => p.ProductId == viewModel.ProductId);
            }
            if (viewModel.EmployeeId != null && viewModel.EmployeeId != -1)
            {
                query = query.Where(p => p.WeightControl.EmployeeId == viewModel.EmployeeId);
            }
            if (viewModel.StartDate != null)
            {
                query = query.Where(p => p.WeightControl.DateStart >= viewModel.StartDate);
            }
            if (viewModel.EndDate != null)
            {
                query = query.Where(p => p.WeightControl.DateStart <= viewModel.EndDate);
            }
            if (viewModel.IsPaid != null)
            {
                query = query.Where(p => p.WeightControl.IsPaid == viewModel.IsPaid);
            }
            if (viewModel.Type != null && viewModel.Type != -1)
            {
                query = query.Where(p => p.WeightControl.WeightControlTypeId == viewModel.Type);
            }
            var result = query.Select(p => new WeightControlReportViewModel
            {
                ProductId = p.ProductId,
                WeightControlDetailId = p.WeightControlDetailId,
                Date = p.WeightControl.DateStart,
                ProductName = p.Product.Name,
                EmployeeName = p.WeightControl.Employee.Name,
                Weight = p.Weight,
                Type = p.WeightControl.WeightControlType.Name,
            }).ToList();

            response.Data = result;

            return response;
        }

        public HttpResponseModel Remainings(bool ViewAll)
        {
            var response = new HttpResponseModel();
            List<Remaining> query = [];
            if (ViewAll)
            {
                query = db.Remainings.Include(p=> p.Product).OrderByDescending(p => p.CreatedDate).ToList();
            }
            else
            {
                var groupedInfo = db.Remainings.Include(p=> p.Product).GroupBy(p => p.ProductId);
                query = groupedInfo.Select(p => p.OrderByDescending(x => x.CreatedDate).FirstOrDefault()).ToList();
            }
            var result = query.Select(p => new RemainigsViewModel
            {
                ProductName = p.Product.Name,
                Weight = p.Weight,
            }).ToList();
            response.Data = result;
            return response;
        }

        public HttpResponseModel PayAndSave(PaymentReceiptRequest viewModel) 
        { 
            var response = new HttpResponseModel();
            foreach (var i in viewModel.Products)
            {
                var detail = db.WeightControlDetails.Where(x => x.WeightControlDetailId == i.WeightControlDetailId).FirstOrDefault();
                if (detail != null)
                {
                    var weightcontrol = db.WeightControls.Where(x=> x.WeightControlId == detail.WeightControlId ).FirstOrDefault();
                    if (weightcontrol != null)
                    {
                        weightcontrol.IsPaid = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        response.StatusMessage = "No se encontro la fk con el id";
                        response.WasSuccessful = false;
                    }
                }
                else
                {
                    response.WasSuccessful = false;
                }
            }

            var newpayment = new Payment
            {
                EmployeeId = viewModel.EmployeeId,
                Date = DateTime.Now,
                TotalWeight = viewModel.TotalWeight,
                TotalPrice = viewModel.TotalToPay
            };
            db.Payments.Add(newpayment);
            foreach (var i in viewModel.Products)
            {
                var newDetail = new PaymentDetail
                {
                    Payment = newpayment,
                    WeightControlDetailId = i.WeightControlDetailId,
                    ProductPrice = i.Price
                };
                db.PaymentDetails.Add(newDetail);
            }
            db.SaveChanges();
            return response;
        }
        public HttpResponseModel GetAllReceipt()
        {
            var response = new HttpResponseModel();

            var bills = db.Payments.Include(p => p.Employee).Select(p => new
                {
                    p.PaymentId,
                    EmployeeName = p.Employee.Name,
                    p.TotalWeight,
                    p.TotalPrice,
                    p.Date
            }).ToList();

            response.Data = bills;
            return response;
        }
        public HttpResponseModel GetReceipt(int id) {
            var response = new HttpResponseModel();
            var query = db.Payments.Include(p => p.Employee).Select(p => new 
            {
                p.PaymentId,
                EmployeeName = p.Employee.Name,
                totalWeight = p.TotalWeight,
                totalToPay = p.TotalPrice,
                p.Date,
                products = db.PaymentDetails.Where(x=> x.PaymentId == id).Select(x=> new
                {
                    id = x.WeightControlDetail.ProductId,
                    name = x.WeightControlDetail.Product.Name,
                    weight = x.WeightControlDetail.Weight,
                    price = x.ProductPrice,
                }) .ToList(),
            }).Where(x => x.PaymentId == id).FirstOrDefault();
            if (query != null)
            {
                response.Data = query;
            }
            else
            {
                response.StatusMessage = "No se encontro el recibo de pago con el id indicado";
                response.WasSuccessful = false;
            }
            return response;
        }
    }
}