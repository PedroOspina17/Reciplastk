using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{
    public class PayrollConfigService
    {
        private readonly ReciplastkContext db;
        private readonly IProductsService productsService;

        public PayrollConfigService(ReciplastkContext db, IProductsService productsService)
        {
            this.productsService = productsService;
            this.db = db;
        }
        public HttpResponseModel GetAll() 
        { 
            var response = new HttpResponseModel();
            var query = db.PayrollConfigs.Where(x=> x.IsActive && x.IsCurrentPrice == true).OrderByDescending(x=> x.IsCurrentPrice).Select(x=> new PayrollConfigViewModel
            {
                CreatedDate = x.CreatedDate,
                Employee = x.Employee.UserName,
                Product = x.Product.ShortName,
                PricePerKilo = x.PricePerKilo,
                IsCurrentePrice = x.IsCurrentPrice,
            }).ToList();
            response.Data = query;
            return response;
        }
        public HttpResponseModel GetById(int id)
        {
            var response = new HttpResponseModel();
            var query = db.PayrollConfigs.Where(x => x.Id == id).FirstOrDefault();
            response.Data = query;
            return response;
        }
        public async Task Create(PayrollConfigRequest payrollConfigViewModel)
        {
            var query = db.PayrollConfigs.Where(x => x.EmployeeId == payrollConfigViewModel.EmployeeId && x.ProductId == payrollConfigViewModel.ProductId && x.IsCurrentPrice == true).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            if (query != null)
            {
                query.IsCurrentPrice = false;
            }
            var newPayrollConfigParent = new PayrollConfig
            {
                ProductId = payrollConfigViewModel.ProductId,
                EmployeeId = payrollConfigViewModel.EmployeeId,
                PricePerKilo = payrollConfigViewModel.PricePerKilo,
                IsCurrentPrice = true,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            db.PayrollConfigs.Add(newPayrollConfigParent);
            //var children = await productsService.GetChildren(payrollConfigViewModel.ProductId);
            //if (children != null)
            //{
            //    foreach (var product in children)
            //    {
            //        var newPayrollConfig = new PayrollConfig
            //        {
            //            ProductId = product.Id,
            //            EmployeeId = payrollConfigViewModel.EmployeeId,
            //            PricePerKilo = payrollConfigViewModel.PricePerKilo,
            //            IsCurrentPrice = true,
            //            CreatedDate = DateTime.Now,
            //            IsActive = true
            //        };

            //        db.PayrollConfigs.Add(newPayrollConfig);
            //    }
            //}
            db.SaveChanges();
        }
       public HttpResponseModel Filter(PayrollConfigRequest payrollConfigViewModel)
        {
            var response = new HttpResponseModel();
            var query = db.PayrollConfigs.Where(x => x.IsActive);
            if (payrollConfigViewModel.EmployeeId != -1)
            {
                query = query.Where(x => x.EmployeeId == payrollConfigViewModel.EmployeeId);
            };
            if (payrollConfigViewModel.ProductId != -1)
            {
                query = query.Where(x => x.ProductId == payrollConfigViewModel.ProductId);
            };
            if (payrollConfigViewModel.ShowAll == false || payrollConfigViewModel.ShowAll == null)
            {
                query = query.Where(x => x.IsCurrentPrice == true);
            };
            var result = query
            .OrderByDescending(x => x.IsCurrentPrice)
            .Select(x => new PayrollConfigViewModel
            {
                CreatedDate = x.CreatedDate,
                Employee = x.Employee.Name +" "+ x.Employee.LastName,
                Product = x.Product.ShortName,
                PricePerKilo = x.PricePerKilo,
                IsCurrentePrice = x.IsCurrentPrice,
            }).ToList();
            response.Data = result;
            response.StatusMessage = "Se filtro correctamente";
            return response;
        }
        public HttpResponseModel Delete(int id) 
        {
            var response = new HttpResponseModel();
            var payRoll = db.PayrollConfigs.Where(x=> x.Id == id).FirstOrDefault();
            if (payRoll != null)
            {
                payRoll.IsActive = false;
                db.SaveChanges();
                response.StatusMessage = "Se eleimino la configuarcion correctamente"; 
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Se eleimino la configuarcion correctamente";
            }
            return response;
        }

    }
}
