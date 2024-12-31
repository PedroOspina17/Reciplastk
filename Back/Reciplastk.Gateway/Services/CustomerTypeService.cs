using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class CustomerTypeService
    {
        private readonly ReciplastkContext db;
        public CustomerTypeService(ReciplastkContext db)
        {
            this.db = db;
        }
        public HttpResponseModel GetAll()
        {
            var customerType = db.Customertypes.Where(x => x.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = customerType;
            return response;
        }
        public HttpResponseModel GetById(int customerTypeId)
        {
            var response = new HttpResponseModel();
            var customerType = GetByid(customerTypeId);
            if (customerType != null)
            {
                response.WasSuccessful = true;
                response.Data = customerType;
                response.StatusMessage = "El tipo de cliente se encontro correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cliente con el id indicado";
            }
            return response;
        }
        private Customertype GetByid(int customerTypeId)
        {
            var customerType = db.Customertypes.Where(x => x.Customertypeid == customerTypeId && x.Isactive == true).FirstOrDefault();
            return customerType;
        }
        public HttpResponseModel Create(CustomerTypeViewModel customerTypeModel)
        {
            var response = new HttpResponseModel();
            var customerType = GetByid(customerTypeModel.customerTypeId);

            var newCustomer = new Customertype();
            newCustomer.Name = customerTypeModel.name;
            newCustomer.Description = customerTypeModel.description;
            newCustomer.Creationdate = DateTime.Now;
            newCustomer.Isactive = customerTypeModel.isactive;
            db.Customertypes.Add(newCustomer);
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El tipo de cliente se creo exitosamente";
            return response;
        }
        public HttpResponseModel Update(CustomerTypeViewModel customerTypeModel)
        {
            var response = new HttpResponseModel();
            var customerType = GetByid(customerTypeModel.customerTypeId);
            if (customerType != null)
            {
                customerType.Customertypeid = customerTypeModel.customerTypeId;
                customerType.Name = customerTypeModel.name;
                customerType.Description = customerTypeModel.description;
                customerType.Updatedate = DateTime.Now;
                customerType.Isactive = customerTypeModel.isactive;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de cliente se edito exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cliente con el id indicado";
            }
            return response;
        }
        public HttpResponseModel Delete(int customerTypeId)
        {
            var response = new HttpResponseModel();
            var customerType = GetByid(customerTypeId);
            if (customerType != null)
            {
                customerType.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de cliente se elimino correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cliente con el id indicado";

            }
            return response;
        }
    }
}

