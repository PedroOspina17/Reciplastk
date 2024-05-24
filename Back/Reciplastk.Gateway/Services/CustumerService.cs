using Azure;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
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
        private Customer CustomerByNit(String customerNit)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Nit == customerNit);
            return customer;
        }
        public HttpResponseModel CreateCustomer(CustomerViewModel customerViewModel)
        {
            var response = new HttpResponseModel();
            var customer = CustomerByNit(customerViewModel.Nit);
            if (customer == null ) {
                var newCustomer = new Customer(); // se hace instancia cuando no hay datos en la db
                newCustomer.Nit = customerViewModel.Nit;
                newCustomer.Name = customerViewModel.Name;
                newCustomer.Lastname = customerViewModel.LastName;
                newCustomer.Address = customerViewModel.Address;
                newCustomer.Cell = customerViewModel.Cell;
                newCustomer.Clientsince = customerViewModel.Clientsince;
                newCustomer.Needspickup = customerViewModel.Needspickup;
                db.Customers.Add( newCustomer );
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = newCustomer;
            }else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The customer was not created";
            }
            return response;
        }   
        public HttpResponseModel EditCustomer(CustomerViewModel customerViewModel) {
            var response = new HttpResponseModel();
            var customer = CustomerById(customerViewModel.Id);
            if (customer != null)
            {
                customer.Nit = customerViewModel.Nit; 
                customer.Name = customerViewModel.Name;
                customer.Lastname = customerViewModel.LastName;
                customer.Address = customerViewModel.Address;
                customer.Cell = customerViewModel.Cell;
                customer.Clientsince = customerViewModel.Clientsince;
                customer.Needspickup = customerViewModel.Needspickup;
                db.SaveChanges();
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
        public HttpResponseModel DeleteCustomer(int customerId) {
            var response = new HttpResponseModel();
            var customer = CustomerById(customerId);
            if (customer != null) {
                db.Remove(customer);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "The customer was deleted successfully";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The customer was not deleted";
            }
            return response;
        }
    }
}
