using Azure;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using System;
using System.Linq;

namespace Reciplastk.Gateway.Services
{
    public class CustomerService
    {
        private readonly ReciplastkContext db;

        public CustomerService(ReciplastkContext db)
        {
            this.db = db;

        }
        public HttpResponseModel GetAll()
        {
            var customer = db.Customers.Where(x => x.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = customer;
            return response;
        }
        public HttpResponseModel Get(int customerid)
        {
            var customer = GetById(customerid);
            var response = new HttpResponseModel();
            if (customer != null)
            {
                response.WasSuccessful = true;
                response.Data = customer;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El id indicadon no esta relacionado con algun cliente";
            }
            return response;
        }
        private Customer GetById(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Customerid == customerId && x.Isactive == true);
            return customer;
        }
        private Customer GetByNit(String customerNit)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Nit == customerNit && x.Isactive == true);
            return customer;
        }
        public HttpResponseModel Create(CustomerViewModel customerViewModel)
        {
            var response = new HttpResponseModel();
            var customer = GetByNit(customerViewModel.nit);
            if (customer == null) // Customer exists with the same nit
            {
                var newCustomer = new Customer(); // se hace instancia cuando no hay datos en la db
                newCustomer.Nit = customerViewModel.nit;
                newCustomer.Customertypeid = customerViewModel.customertypeid;
                newCustomer.Name = customerViewModel.name;
                newCustomer.Lastname = customerViewModel.lastname;
                newCustomer.Address = customerViewModel.address;
                newCustomer.Cell = customerViewModel.cell;
                newCustomer.Needspickup = customerViewModel.needspickup;
                newCustomer.Clientsince = customerViewModel.clientsince;
                newCustomer.Createddate = DateTime.Now;
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = newCustomer;
                response.StatusMessage = "El cliente fue creado exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Ya existed un cliente con este mismo NIT";
            }

            return response;
        }
        public HttpResponseModel Update(CustomerViewModel customerViewModel)
        {
            var response = new HttpResponseModel();
            var customer = GetById(customerViewModel.customerid ?? -1);
            if (customer != null)
            {
                customer.Nit = customerViewModel.nit;
                customer.Name = customerViewModel.name;
                customer.Lastname = customerViewModel.lastname;
                customer.Address = customerViewModel.address;
                customer.Cell = customerViewModel.cell;
                customer.Clientsince = customerViewModel.clientsince;
                customer.Needspickup = customerViewModel.needspickup;
                customer.Updateddate = DateTime.Now;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = customer;
                response.StatusMessage = "El cliente fue editado exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No existe ningun cliente con el Id especificado";
            }
            return response;
        }
        public HttpResponseModel Delete(int customerId)
        {
            var response = new HttpResponseModel();
            var customer = GetById(customerId);
            if (customer != null)
            {
                customer.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El cliente fue eliminado exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontró ningún cliente con el Id especificado";
            }
            return response;
        }
    }
}
