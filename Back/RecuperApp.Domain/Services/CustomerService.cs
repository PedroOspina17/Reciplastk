using Microsoft.EntityFrameworkCore;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class CustomerService
    {
        private readonly ReciplastkContext db;
        private readonly ProductPricesService productPricesService;

        public CustomerService(ReciplastkContext db, ProductPricesService productPricesService)
        {
            this.db = db;
            this.productPricesService = productPricesService;
        }
        public HttpResponseModel GetAll()
        {
            var customer = db.Customers.Include(p => p.CustomerType).Where(x => x.IsActive == true).Select(y => new CustomerViewModel()
            {
                customerid = y.CustomerId,
                customertypeid = y.CustomerTypeId,
                customertypename = y.CustomerType.Name,
                nit = y.Nit,
                name = y.Name,
                lastname = y.LastName,
                address = y.Address,
                cell = y.Cell,
                needspickup = y.NeedsPickup,
                clientsince = y.ClientSince,
            }).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = customer
            };
            return response;
        }
        public HttpResponseModel GetAllCustomer()
        {
            var customer = db.Customers.Include(p=> p.CustomerType).Where(x => x.IsActive == true && x.CustomerTypeId == (int)Enums.CustomerTypeEnum.Customer).Select(y=> new CustomerViewModel()
            {
                customerid = y.CustomerId,
                customertypeid = y.CustomerTypeId,
                customertypename = y.CustomerType.Name,
                nit = y.Nit,
                name = y.Name,
                lastname = y.LastName,
                address = y.Address,
                cell = y.Cell,
                needspickup = y.NeedsPickup,
                clientsince = y.ClientSince,
            }).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = customer
            };
            return response;
        }
        public HttpResponseModel GetAllProviders()
        {
            var customer = db.Customers.Include(p => p.CustomerType).Where(x => x.IsActive == true && x.CustomerTypeId == (int)Enums.CustomerTypeEnum.Provider).Select(y => new CustomerViewModel()
            {
                customerid = y.CustomerId,
                customertypeid = y.CustomerTypeId,
                customertypename = y.CustomerType.Name,
                nit = y.Nit,
                name = y.Name,
                lastname = y.LastName,
                address = y.Address,
                cell = y.Cell,
                needspickup = y.NeedsPickup,
                clientsince = y.ClientSince,
            }).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = customer
            };
            return response;
        }
        public HttpResponseModel GetCustomer(int customerid)
        {
            var customer = GetCustomerById(customerid);
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
        private Customer GetCustomerById(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(x => x.CustomerId == customerId && x.IsActive == true && x.CustomerTypeId == 2);
            return customer;
        }
        public HttpResponseModel GetProvider(int providerid)
        {
            var customer = GetProviderById(providerid);
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
        private Customer GetProviderById(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(x => x.CustomerId == customerId && x.IsActive == true && x.CustomerTypeId == 1);
            return customer;
        }
        private Customer GetByNit(String customerNit)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Nit == customerNit && x.IsActive == true);
            return customer;
        }
        public HttpResponseModel Create(CustomerViewModel customerViewModel)
        {
            var response = new HttpResponseModel();
            var customer = GetByNit(customerViewModel.nit);
            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    Nit = customerViewModel.nit,
                    CustomerTypeId = customerViewModel.customertypeid,
                    Name = customerViewModel.name,
                    LastName = customerViewModel.lastname,
                    Address = customerViewModel.address,
                    Cell = customerViewModel.cell,
                    NeedsPickup = customerViewModel.needspickup,
                    ClientSince = customerViewModel.clientsince,
                    CreatedDate = DateTime.Now
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                this.productPricesService.CreatePriceForNewCustomer(newCustomer);
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
            var customer = GetCustomerById(customerViewModel.customerid ?? -1);
            if (customer != null)
            {
                customer.Nit = customerViewModel.nit;
                customer.Name = customerViewModel.name;
                customer.LastName = customerViewModel.lastname;
                customer.Address = customerViewModel.address;
                customer.Cell = customerViewModel.cell;
                customer.ClientSince = customerViewModel.clientsince;
                customer.NeedsPickup = customerViewModel.needspickup;
                customer.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = customer;
                response.StatusMessage = "El cliente fue editado exitosamente";
            }
            else
            {
                customer = GetProviderById(customerViewModel.customerid ?? -1);
                if (customer != null)
                {
                    customer.Nit = customerViewModel.nit;
                    customer.Name = customerViewModel.name;
                    customer.LastName = customerViewModel.lastname;
                    customer.Address = customerViewModel.address;
                    customer.Cell = customerViewModel.cell;
                    customer.ClientSince = customerViewModel.clientsince;
                    customer.NeedsPickup = customerViewModel.needspickup;
                    customer.UpdatedDate = DateTime.Now;
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
            }
            return response;
        }
        public HttpResponseModel Delete(int customerId)
        {
            var response = new HttpResponseModel();
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                customer.IsActive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El cliente fue eliminado exitosamente";
            }
            else
            {
                customer = GetProviderById(customerId);
                if (customer != null)
                {
                    customer.IsActive = false;
                    db.SaveChanges();
                    response.WasSuccessful = true;
                    response.StatusMessage = "El cliente fue eliminado exitosamente";
                }
                else
                {
                    response.WasSuccessful = false;
                    response.StatusMessage = "No se encontró ningún cliente con el Id especificado";
                }

            }
            return response;
        }
    }
}
