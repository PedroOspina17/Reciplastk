using Azure;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using System;
using System.Linq;

namespace Reciplastk.Gateway.Services
{
    public class CustumerService
    {
        private readonly ReciplastkContext db;
        
        public CustumerService(ReciplastkContext db)
        {
            this.db = db;

        }
        public HttpResponseModel ShowAllCustomers()
        {
            var customer = db.Customers.ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = customer;
            return response;
        }
        public HttpResponseModel ShowCustomer(int customerid)
        {
            var customer = db.Customers.Where(x => x.Customerid == customerid).FirstOrDefault();
            var response = new HttpResponseModel();
            if (customer != null)
            {
                response.WasSuccessful = true;
                response.Data = customer;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The customer was not found";
            }
            return response;
        }
        private Customer CustomerById(int? customerId)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Customerid == customerId);
            return customer;
        }
        private Customer GetCustomerByNit(String customerNit)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Nit == customerNit);
            return customer;
        }
        public HttpResponseModel CreateCustomer(CustomerViewModel customerViewModel)
        {
            var response = new HttpResponseModel();
            var customer = GetCustomerByNit(customerViewModel.nit);
            if (customer == null ) {
                var newCustomer = new Customer(); // se hace instancia cuando no hay datos en la db
                newCustomer.Nit = customerViewModel.nit;
                newCustomer.Name = customerViewModel.name;
                newCustomer.Lastname = customerViewModel.lastname;
                newCustomer.Address = customerViewModel.address;
                newCustomer.Cell = customerViewModel.cell;
                newCustomer.Needspickup = customerViewModel.needspickup;
                newCustomer.Clientsince = DateTime.Now;
                db.Customers.Add( newCustomer );
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = newCustomer;
                response.StatusMessage = "El cliente fue creado exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Ya existe otro cliente con el NIT indicado";
            }
            return response;
        }   
        public HttpResponseModel EditCustomer(CustomerViewModel customerViewModel) {
            var response = new HttpResponseModel();
            var customer = CustomerById(customerViewModel.customerid);
            if (customer != null)
            {
                customer.Nit = customerViewModel.nit; 
                customer.Name = customerViewModel.name;
                customer.Lastname = customerViewModel.lastname;
                customer.Address = customerViewModel.address;
                customer.Cell = customerViewModel.cell;
                customer.Clientsince = DateTime.Now;
                customer.Needspickup = customerViewModel.needspickup;
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
        public HttpResponseModel DeleteCustomer(int customerId) {
            var response = new HttpResponseModel();
            var customer = CustomerById(customerId);
            if (customer != null) {
                db.Remove(customer);
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
