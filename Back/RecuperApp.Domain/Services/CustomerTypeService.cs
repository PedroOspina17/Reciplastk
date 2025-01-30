using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
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
            var customerType = db.CustomerTypes.Where(x => x.IsActive == true).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = customerType
            };
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
        private CustomerType GetByid(int customerTypeId)
        {
            var customerType = db.CustomerTypes.Where(x => x.Id == customerTypeId && x.IsActive == true).FirstOrDefault();
            return customerType;
        }
        private CustomerType GetByName(string customerTypeName)
        {
            var shipmentType = db.CustomerTypes.Where(x => x.Name == customerTypeName && x.IsActive == true).FirstOrDefault();
            return shipmentType;
        }
        public HttpResponseModel Create(CustomerTypeRequest customerTypeModel)
        {
            var response = new HttpResponseModel();
            var customerType = GetByName(customerTypeModel.Name);
            if (customerType != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Ya existe un tipo con el mismo nombre.";

            }
            else
            {
                var newCustomer = new CustomerType
                {
                    Name = customerTypeModel.Name,
                    Description = customerTypeModel.Description,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                db.CustomerTypes.Add(newCustomer);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de cliente se creo exitosamente";
            }
            return response;
        }
        public HttpResponseModel Update(CustomerTypeRequest customerTypeModel)
        {
            var response = new HttpResponseModel();
            var customerType = GetByid(customerTypeModel.CustomerTypeId);
            if (customerType != null)
            {
                customerType.Description = customerTypeModel.Description;
                customerType.UpdatedDate = DateTime.Now;
                customerType.IsActive = true;
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
                customerType.IsActive = false;
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

