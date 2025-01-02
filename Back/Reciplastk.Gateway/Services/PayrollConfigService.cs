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
            var query = db.Payrollconfigs.Where(x=> x.Isactive).ToList();
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
            var newPayrollConfig = new Payrollconfig();
            newPayrollConfig.Productid = payrollConfigViewModel.productid;
            newPayrollConfig.Employeeid = payrollConfigViewModel.employeeid;
            newPayrollConfig.Priceperkilo = payrollConfigViewModel.priceperkilo;
            newPayrollConfig.Iscurrentprice = payrollConfigViewModel.iscurrentePrice;
            newPayrollConfig.Creationdate = DateTime.Now;
            newPayrollConfig.Isactive = true;
            db.Payrollconfigs.Add(newPayrollConfig);
            db.SaveChanges();
            response.StatusMessage = "Se creo la configuracion correctamente";
            return response;
        }
        public HttpResponseModel Update(PayrollConfigViewModel payrollConfigViewModel) 
        {
            var response = new HttpResponseModel();
            return response;
        }
        public HttpResponseModel Delete(int id) 
        {
            var response = new HttpResponseModel();
            return response;
        }

    }
}
