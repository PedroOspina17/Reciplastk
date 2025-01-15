using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class PayrollConfigService
    {
        private readonly ReciplastkContext db; 

        public PayrollConfigService(ReciplastkContext db)
        {
            this.db = db;
        }
        public HttpResponseModel GetAll() 
        { 
            var response = new HttpResponseModel();
            var query = db.Payrollconfigs.Where(x=> x.Isactive && x.Iscurrentprice == true).OrderByDescending(x=> x.Iscurrentprice).Select(x=> new PayrollConfigParams
            {
                creationdate = x.Creationdate,
                employee = x.Employee.Username,
                product = x.Product.Shortname,
                buyPrice = x.Priceperkilo,
                isCurrentePrice = x.Iscurrentprice,
            }).ToList();
            response.Data = query;
            return response;
        }
        public HttpResponseModel GetById(int id)
        {
            var response = new HttpResponseModel();
            var query = db.Payrollconfigs.Where(x => x.Payrollconfigid == id).FirstOrDefault();
            response.Data = query;
            return response;
        }
        public HttpResponseModel Create(PayrollConfigViewModel payrollConfigViewModel) 
        {
            var response = new HttpResponseModel();
            var query = db.Payrollconfigs.Where(x=> x.Employeeid == payrollConfigViewModel.employeeid && x.Productid == payrollConfigViewModel.productid && x.Iscurrentprice == true).OrderByDescending(x=> x.Creationdate).FirstOrDefault();
            if (query != null)
            {
                query.Iscurrentprice = false;
            }
            var newPayrollConfig = new Payrollconfig();
            newPayrollConfig.Productid = payrollConfigViewModel.productid;
            newPayrollConfig.Employeeid = payrollConfigViewModel.employeeid;
            newPayrollConfig.Priceperkilo = payrollConfigViewModel.priceperkilo;
            newPayrollConfig.Iscurrentprice = true;
            newPayrollConfig.Creationdate = DateTime.Now;
            newPayrollConfig.Isactive = true;
            db.Payrollconfigs.Add(newPayrollConfig);
            db.SaveChanges();
            response.StatusMessage = "Se creo la configuracion correctamente";
            return response;
        }
       public HttpResponseModel Filter(PayrollConfigViewModel payrollConfigViewModel)
        {
            var response = new HttpResponseModel();
            var query = db.Payrollconfigs.Where(x => x.Isactive);
            if (payrollConfigViewModel.employeeid != -1)
            {
                query = query.Where(x => x.Employeeid == payrollConfigViewModel.employeeid);
            };
            if (payrollConfigViewModel.productid != -1)
            {
                query = query.Where(x => x.Productid == payrollConfigViewModel.productid);
            };
            if (payrollConfigViewModel.showAll == false || payrollConfigViewModel.showAll == null)
            {
                query = query.Where(x => x.Iscurrentprice == true);
            };
            var result = query
            .OrderByDescending(x => x.Iscurrentprice)
            .Select(x => new PayrollConfigParams
            {
                creationdate = x.Creationdate,
                employee = x.Employee.Name +" "+ x.Employee.Lastname,
                product = x.Product.Shortname,
                buyPrice = x.Priceperkilo,
                isCurrentePrice = x.Iscurrentprice,
            }).ToList();
            response.Data = result;
            response.StatusMessage = "Se filtro correctamente";
            return response;
        }
        public HttpResponseModel Delete(int id) 
        {
            var response = new HttpResponseModel();
            var payRoll = db.Payrollconfigs.Where(x=> x.Payrollconfigid == id).FirstOrDefault();
            if (payRoll != null)
            {
                payRoll.Isactive = false;
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
