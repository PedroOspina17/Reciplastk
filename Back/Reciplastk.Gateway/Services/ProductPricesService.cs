using Azure;
using Microsoft.EntityFrameworkCore;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class ProductPricesService
    {
        private readonly ReciplastkContext db;
        private readonly CustomerService customerService;

        public ProductPricesService(ReciplastkContext db, CustomerService customerService)
        {
            this.db = db;
            this.customerService = customerService;
        }
        public HttpResponseModel GetAllPriceTypes()
        {
            var response = new HttpResponseModel();
            var pricestypes = db.Pricetypes.Where(x => x.Isactive == true).ToList();
            if (pricestypes != null)
            {
                response.Data = pricestypes;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No existen tipos de precios en la base de datos";
            }
            return response;
        }
        public HttpResponseModel GetAllProductPrices()
        {
            var response = new HttpResponseModel();
            var productprices = db.Productprices.Where(x => x.Isactive == true).ToList();
            if (productprices != null)
            {
                response.Data = productprices;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No existen precios de los productoas en la base de datos";
            }
            return response;
        }
        public HttpResponseModel GetPriceTypesById(int id)
        {
            var response = new HttpResponseModel();
            var pricestypes = db.Pricetypes.Where(x => x.Isactive == true && x.Pricetypeid == id).FirstOrDefault();
            if (pricestypes != null)
            {
                response.Data = pricestypes;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontraron los tipos de precios con el id indicado";
            }
            return response;
        }
        public HttpResponseModel GetProductPricesById(int id)
        {
            var response = new HttpResponseModel();
            var productprices = db.Productprices.Where(x => x.Isactive == true && x.Productpriceid == id).FirstOrDefault();
            if (productprices != null)
            {
                response.Data = productprices;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontraron los precios de los productoas con el id indicado";
            }
            return response;
        }
        public HttpResponseModel CreatePriceTypes(PriceTypeViewModel priceTypeViewModel)
        {
            var response = new HttpResponseModel();
            var newObject = new Pricetype();
            newObject.Name = priceTypeViewModel.name;
            newObject.Description = priceTypeViewModel.description;
            newObject.Creationdate = DateTime.Now;
            newObject.Isactive = true;
            db.Pricetypes.Add(newObject);
            db.SaveChanges();
            response.StatusMessage = "Se creo el tipo precio correctamente";
            return response;
        }
        public HttpResponseModel GetCurrentPrice(int productid, int customerid, int pricetypeid)
        {
            var response = new HttpResponseModel();
            var query = db.Productprices.Where(x => x.Productid == productid && x.Customerid == customerid && x.Pricetypeid == pricetypeid)
                .OrderByDescending(x => x.Creationdate)
                .Select(y => y.Price).FirstOrDefault();

            response.Data = query;
            return response;
        }
        public HttpResponseModel CreateProductPrices(ProductPricesViewModel productPricesViewModel)
        {
            var response = new HttpResponseModel();
            if (productPricesViewModel.customerid != null)
            {
                var newObject = new Productprice();
                newObject.Productid = productPricesViewModel.productid;
                newObject.Customerid = productPricesViewModel.customerid.Value;
                newObject.Pricetypeid = productPricesViewModel.pricetypeid;
                newObject.Employeeid = 29; ; // To do: get from logged in user
                newObject.Price = productPricesViewModel.price;
                newObject.Creationdate = DateTime.Now;
                newObject.Isactive = true;
                db.Productprices.Add(newObject);
                db.SaveChanges();
                response.StatusMessage = "Se creo el precio del producto correctamente";
                return response;
            }
            else
            {
                return this.CreatePriceForAllCustomers(productPricesViewModel);
            }
        }
        public HttpResponseModel CreatePriceForAllCustomers(ProductPricesViewModel productPricesViewModel)
        {
            var response = new HttpResponseModel();
            List<CustomerViewModel> customers;
            if (productPricesViewModel.pricetypeid == 1)
            {
                customers = (List<CustomerViewModel>)this.customerService.GetAllProviders().Data;
            }
            else
            {
                customers = (List<CustomerViewModel>)this.customerService.GetAllCustomer().Data;
            }
            foreach (var customer in customers)
            {
                var currentprice = (double)this.GetCurrentPrice(productPricesViewModel.productid, customer.customerid.Value, productPricesViewModel.pricetypeid).Data;
                var newObject = new Productprice();
                newObject.Productid = productPricesViewModel.productid;
                newObject.Customerid = customer.customerid.Value;
                newObject.Pricetypeid = productPricesViewModel.pricetypeid;
                newObject.Employeeid = 29; ; // To do: get from logged in user
                newObject.Price = currentprice + productPricesViewModel.price;
                newObject.Creationdate = DateTime.Now;
                newObject.Isactive = true;
                db.Productprices.Add(newObject);
            }
            db.SaveChanges();
            response.StatusMessage = "Se creo el precio del producto correctamente";
            return response;

        }
        public HttpResponseModel Filter(FilterViewModel filterViewModel)
        {
            var response = new HttpResponseModel();
            var query = db.Productprices.Where(z => z.Pricetypeid == filterViewModel.pricetypeid && z.Productid == filterViewModel.productid);
            if (filterViewModel.customerid != null && filterViewModel.customerid != -1)
            {
                query = query.Where(x => x.Customerid == filterViewModel.customerid);
            };
            var result = query.Select(x => new ProductPriceInnerParams
            {
                date = x.Creationdate,
                employee = x.Employee.Name,
                customer = x.Customer.Name,
                price = x.Price,
                isactive = x.Isactive,
            });
            response.Data = result;
            return response;
        }
        public HttpResponseModel CreatePricesForNewProducts(ProductsViewModel ProductsModel)
        {
            var response = new HttpResponseModel();
            this.CreatePriceForNewProducts(ProductsModel); // Create prices for parent product 
            if (ProductsModel.Issubtype) {
                foreach (var subproduct in ProductsModel.SubtypeProductList)
                {
                    this.CreatePriceForNewProducts(subproduct);
                }
            }
            return response;           
        }
        private bool CreatePriceForNewProducts(ProductsViewModel ProductsModel)
        {
            var BuyPriceViewModel = new ProductPricesViewModel()
            {
                productid = ProductsModel.productref.Productid,
                pricetypeid = 1,
                employeeid = 29, // To do: replace for a config value
                price = ProductsModel.Buyprice,
            };
            var result = this.CreatePriceForAllCustomers(BuyPriceViewModel).WasSuccessful;
            if (result)
            {
                BuyPriceViewModel = new ProductPricesViewModel()
                {
                    productid = ProductsModel.productref.Productid,
                    pricetypeid = 2,
                    employeeid = 29, // To do: replace for a config value
                    price = ProductsModel.Sellprice,
                };
                return this.CreatePriceForAllCustomers(BuyPriceViewModel).WasSuccessful;
            }
            else
            {
                return false;
            }

        }

        // create a metod CreatePricesForNewProducts to receipt this view model ProductsViewModel
        // create the two type of prices for general and specific products 
        // in products services call this new metod after savechanges 
    }
}
