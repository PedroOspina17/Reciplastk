using Azure;
using Microsoft.EntityFrameworkCore;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class WeightControlService
    {

        private readonly ReciplastkContext db;
        public WeightControlService(ReciplastkContext db)
        {
            this.db = db;
        }
        private Weightcontrol FindById(int id)
        {
            var weightcontrol = db.Weightcontrols.Where(p => p.Isactive == true && p.Weightcontrolid == id).FirstOrDefault();
            return weightcontrol;

        }
        public HttpResponseModel GetAll()
        {
            var weightControl = db.Weightcontrols.Where(p => p.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = weightControl;
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

        public HttpResponseModel CreateSeparation(WeightControlViewModel model)
        {
            var response = new HttpResponseModel();

            var newWeightControl = new Weightcontrol();
            newWeightControl.Employeeid = model.Employeeid;
            newWeightControl.Weightcontroltypeid = 1; // To do: Change to config value.
            newWeightControl.Datestart = DateTime.Now;
            newWeightControl.Ispaid = false;
            newWeightControl.Creationdate = DateTime.Now;
            newWeightControl.Isactive = true;
            db.Weightcontrols.Add(newWeightControl);
            foreach (var i in model.weightdetail)
            {
                var detail = new Weightcontroldetail();
                detail.Weightcontrol = newWeightControl;
                detail.Productid = i.ProductId;
                detail.Weight = i.Weight;
                db.Weightcontroldetails.Add(detail);
            }
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El dato fue agregado correctamente";
            return response;
        }
        public HttpResponseModel CreateGrinding(GrindingViewModel model)
        {
            var response = new HttpResponseModel();
            var newWeightControl = new Weightcontrol();
            newWeightControl.Employeeid = 29; // To do: replace with confing value
            newWeightControl.Weightcontroltypeid = 2; // To do: replace with confing value
            newWeightControl.Datestart = DateTime.Now;
            newWeightControl.Ispaid = false;
            newWeightControl.Creationdate = DateTime.Now;
            newWeightControl.Isactive = true;
            db.Weightcontrols.Add(newWeightControl);

            var detail = new Weightcontroldetail();
            detail.Weightcontrol = newWeightControl;
            detail.Weight = model.PackageCount * 25; // To do: replace with confing value
            detail.Productid = model.ProductId;
            db.Weightcontroldetails.Add(detail);

            var remainig = new Remaining();
            remainig.Weightcontrol = newWeightControl;
            remainig.Productid = model.ProductId;
            remainig.Weight = model.Remainig;
            remainig.Creationdate = DateTime.Now;
            remainig.Isactive = true;
            db.Remainings.Add(remainig);

            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El dato fue agregado correctamente";
            return response;
        }
        public HttpResponseModel Update(WeightControlViewModel model)
        {
            var weightcontrol = FindById(model.Weightcontrolid ?? -1);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                weightcontrol.Employeeid = model.Employeeid;
                weightcontrol.Ispaid = false;
                weightcontrol.Updatedate = DateTime.Now;
                weightcontrol.Isactive = false;
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
                weightcontrol.Dateend = DateTime.Now;
                weightcontrol.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            return response;
        }

        public HttpResponseModel GetGroundProducts()
        {
            var response = new HttpResponseModel();
            var query = db.Weightcontroldetails
                .Where(w => w.Weightcontrol.Isactive && w.Weightcontrol.Weightcontroltypeid == 2 && w.Weightcontrol.Datestart > DateTime.Today && w.Weightcontrol.Datestart < DateTime.Today.AddDays(1))
                .Select(w => new GroundProductViewModel()
                {
                    detailId = w.Weightcontroldetailid,
                    controlId = w.Weightcontrolid,
                    Weight = w.Weight,
                    ProductName = w.Product.Name,
                    DateStart = w.Weightcontrol.Datestart,
                    Remaining = (w.Weightcontrol.Remainings.Count <= 0 ? 0 : w.Weightcontrol.Remainings.FirstOrDefault().Weight),
                })
            .OrderByDescending(w => w.detailId)
            .ToList();

            response.WasSuccessful = true;
            response.Data = query;
            return response;
        }
       
        public HttpResponseModel Filter(WeightControlReportParams viewModel)
        {
            var response = new HttpResponseModel();
            var query = db.Weightcontroldetails.Where(p => p.Weightcontrol.Isactive == true && p.Weightcontrol.Ispaid == false);
            if (viewModel.ProductId != null && viewModel.ProductId != -1)
            {
                query = query.Where(p => p.Productid == viewModel.ProductId);
            }
            if (viewModel.EmployeeId != null && viewModel.EmployeeId != -1)
            {
                query = query.Where(p => p.Weightcontrol.Employeeid == viewModel.EmployeeId);
            }
            if (viewModel.StartDate != null)
            {
                query = query.Where(p => p.Weightcontrol.Datestart >= viewModel.StartDate);
            }
            if (viewModel.EndDate != null)
            {
                query = query.Where(p => p.Weightcontrol.Datestart <= viewModel.EndDate);
            }
            if (viewModel.Ispaid != null)
            {
                query = query.Where(p => p.Weightcontrol.Ispaid == viewModel.Ispaid);
            }
            if (viewModel.Type != null && viewModel.Type != -1)
            {
                query = query.Where(p => p.Weightcontrol.Weightcontroltypeid == viewModel.Type);
            }
            var result = query.Select(p => new WeightControlReport
            {
                productid = p.Productid,
                date = p.Weightcontrol.Datestart,
                productName = p.Product.Name,
                employeeName = p.Weightcontrol.Employee.Name,
                weight = p.Weight,
                type = p.Weightcontrol.Weightcontroltype.Name,
            }).ToList();

            response.Data = result;

            return response;
        }

        public HttpResponseModel Remainings(bool ViewAll)
        {
            var response = new HttpResponseModel();
            List<Remaining> query = new List<Remaining>();
            if (ViewAll)
            {
                query = db.Remainings.Include(p=> p.Product).OrderByDescending(p => p.Creationdate).ToList();
            }
            else
            {
                var groupedInfo = db.Remainings.Include(p=> p.Product).GroupBy(p => p.Productid);
                query = groupedInfo.Select(p => p.OrderByDescending(x => x.Creationdate).FirstOrDefault()).ToList();
            }
            var result = query.Select(p => new RemainigResponse
            {
                productName = p.Product.Name,
                weight = p.Weight,
            }).ToList();
            response.Data = result;
            return response;
        }

        public HttpResponseModel PayAndSave(PaymentReceiptParams viewModel) 
        { 
            var response = new HttpResponseModel();
            foreach (var i in viewModel.products)
            {
                var detail = db.Weightcontroldetails.Where(x => x.Weightcontroldetailid == i.id).FirstOrDefault();
                if (detail != null)
                {
                    var weightcontrol = db.Weightcontrols.Where(x=> x.Weightcontrolid == detail.Weightcontrolid ).FirstOrDefault();
                    if (weightcontrol != null)
                    {
                        weightcontrol.Ispaid = true;
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

            var newpaymaent = new Payment();
            newpaymaent.Employeid = viewModel.employeeId;
            newpaymaent.Date = DateTime.Now;
            newpaymaent.Totalweight = viewModel.totalWeight;
            newpaymaent.Totalprice = viewModel.totalToPay;
            db.Payments.Add(newpaymaent);
            foreach (var i in viewModel.products)
            {
                var newDetail = new Paymentdetail();
                newDetail.Payment = newpaymaent;
                newDetail.Paymentid = i.id;
                newDetail.Weightcontroldetailid = i.id;
                newDetail.Productprice = i.price;
                db.Paymentdetails.Add(newDetail);
            }
            db.SaveChanges();
            return response;
        }
        public HttpResponseModel GetAllReceipt()
        {
            var response = new HttpResponseModel();

            var bills = db.Payments.Include(p => p.Employe).Select(p => new
                {
                    p.Paymentid,
                    EmployeeName = p.Employe.Name,
                    p.Totalweight,
                    p.Totalprice,
                    p.Date
            }).ToList();

            response.Data = bills;
            return response;
        }
        public HttpResponseModel GetReceipt(int id) {
            var response = new HttpResponseModel();
            var query = db.Payments.Include(p => p.Employe).Select(p => new 
            {
                p.Paymentid,
                EmployeeName = p.Employe.Name,
                totalWeight = p.Totalweight,
                totalToPay = p.Totalprice,
                p.Date,
                products = db.Paymentdetails.Where(x=> x.Paymentid == id).Select(x=> new
                {
                    id = x.Weightcontroldetail.Productid,
                    name = x.Weightcontroldetail.Product.Name,
                    weight = x.Weightcontroldetail.Weight,
                    price = x.Productprice,
                }) .ToList(),
            }).Where(x => x.Paymentid == id).FirstOrDefault();
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