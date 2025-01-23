using Microsoft.EntityFrameworkCore;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Models.Requests;

namespace RecuperApp.Domain.Services
{
    public class ProductPricesService
    {
        private readonly ReciplastkContext db;

        public ProductPricesService(ReciplastkContext db)
        {
            this.db = db;
        }
        public HttpResponseModel GetAllPriceTypes()
        {
            var response = new HttpResponseModel();
            var pricestypes = db.PriceTypes.Where(x => x.IsActive == true).ToList();
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
            var productprices = db.ProductPrices.Where(x => x.IsActive == true).ToList();
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
            var pricestypes = db.PriceTypes.Where(x => x.IsActive == true && x.PriceTypeId == id).FirstOrDefault();
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
            var productprices = db.ProductPrices.Where(x => x.IsActive == true && x.ProductPriceId == id).FirstOrDefault();
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
        public HttpResponseModel CreatePriceTypes(PriceTypeRequest priceTypeViewModel)
        {
            var response = new HttpResponseModel();
            var newObject = new PriceType
            {
                Name = priceTypeViewModel.name,
                Description = priceTypeViewModel.description,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            db.PriceTypes.Add(newObject);
            db.SaveChanges();
            response.StatusMessage = "Se creo el tipo precio correctamente";
            return response;
        }

        public HttpResponseModel GetCurrentPrice(int productid, int pricetypeid)
        {
            var lastestPrice = GetLatestPrice(); // Gets latest customer a customer
            var response = new HttpResponseModel();
            var query = db.ProductPrices
                .Where(x => x.ProductId == productid && x.CustomerId == lastestPrice.CustomerId && x.PricetypeId == pricetypeid && x.IsCurrentPrice == true)
                .OrderByDescending(x => x.CreatedDate)
                .Select(y => y.Price).FirstOrDefault();

            response.Data = query;
            return response;
        }

        public HttpResponseModel GetCurrentPrice(int productid, int customerid, int pricetypeid)
        {
            var response = new HttpResponseModel();
            var query = db.ProductPrices
                .Where(x => x.ProductId == productid && x.CustomerId == customerid && x.PricetypeId == pricetypeid && x.IsCurrentPrice == true)
                .OrderByDescending(x => x.CreatedDate)
                .Select(y => y.Price).FirstOrDefault();

            response.Data = query;
            return response;
        }
        public HttpResponseModel CreateProductPrices(ProductPricesRequest productPricesViewModel)
        {
            var response = new HttpResponseModel();
            if (productPricesViewModel.customerid != null)
            {
                var query = db.ProductPrices
                    .Where(x => x.ProductId == productPricesViewModel.productid && x.CustomerId == productPricesViewModel.customerid.Value && x.PricetypeId == productPricesViewModel.pricetypeid && x.IsCurrentPrice == true).FirstOrDefault();
                query.IsCurrentPrice = false;
                var newObject = new ProductPrice
                {
                    ProductId = productPricesViewModel.productid,
                    CustomerId = productPricesViewModel.customerid.Value,
                    PricetypeId = productPricesViewModel.pricetypeid,
                    EmployeeId = 29
                };
                ; // To do: get from logged in user
                newObject.Price = productPricesViewModel.price;
                newObject.CreatedDate = DateTime.Now;
                newObject.IsActive = true;
                newObject.IsCurrentPrice = true;
                db.ProductPrices.Add(newObject);
                db.SaveChanges();
                response.StatusMessage = "Se creo el precio del producto correctamente";
                return response;
            }
            else
            {
                return this.CreatePriceForAllCustomers(productPricesViewModel);
            }
        }
        public HttpResponseModel CreatePriceForAllCustomers(ProductPricesRequest productPricesViewModel)
        {
            var response = new HttpResponseModel();
            List<Customer> customers;
            if (productPricesViewModel.pricetypeid == (int)Enums.PriceTypeEnum.Buy)
            {
                customers = db.Customers.Where(x => x.IsActive == true && x.CustomerTypeId == (int)Enums.CustomerTypeEnum.Provider).ToList();
            }
            else
            {
                customers = db.Customers.Where(x => x.IsActive == true && x.CustomerTypeId == (int)Enums.CustomerTypeEnum.Customer).ToList();
            }
            var query = db.ProductPrices.Where(x => x.ProductId == productPricesViewModel.productid && x.PricetypeId == productPricesViewModel.pricetypeid && x.IsCurrentPrice == true).ToList();
            query.ForEach(x => x.IsCurrentPrice = false);
            foreach (var customer in customers)
            {
                //customer.Iscurrentprice = false;
                var currentprice = (double)this.GetCurrentPrice(productPricesViewModel.productid, customer.CustomerId, productPricesViewModel.pricetypeid).Data;
                var newObject = new ProductPrice
                {
                    ProductId = productPricesViewModel.productid,
                    CustomerId = customer.CustomerId,
                    PricetypeId = productPricesViewModel.pricetypeid,
                    EmployeeId = 29
                };
                ; // To do: get from logged in user
                newObject.Price = currentprice + productPricesViewModel.price;
                newObject.CreatedDate = DateTime.Now;
                newObject.IsActive = true;
                newObject.IsCurrentPrice = true;
                db.ProductPrices.Add(newObject);
            }
            db.SaveChanges();
            response.StatusMessage = "Se creo el precio del producto correctamente";
            return response;

        }
        public HttpResponseModel Filter(ProductPriceFilterRequest filterViewModel)
        {
            var response = new HttpResponseModel();
            var query = db.ProductPrices.Where(x => x.Customer.IsActive == true);
            if (filterViewModel.customerid != null && filterViewModel.customerid != -1)
            {
                query = query.Where(x => x.CustomerId == filterViewModel.customerid);
            };
            if (filterViewModel.productid != null && filterViewModel.productid != -1)
            {
                query = query.Where(x => x.ProductId == filterViewModel.productid);
            };
            if (filterViewModel.pricetypeid != null && filterViewModel.pricetypeid != -1)
            {
                query = query.Where(x => x.PricetypeId == filterViewModel.pricetypeid);
            };
            if (filterViewModel.ShowHistory != null && filterViewModel.ShowHistory == false)
            {
                query = query.Where(x => x.IsCurrentPrice == !filterViewModel.ShowHistory);
            }
            var result = query
            .OrderByDescending(x => x.IsCurrentPrice)
            .ThenByDescending(x => x.CreatedDate)
            .ThenByDescending(x => x.CustomerId)
            .Select(x => new ProductPriceViewModel
            {
                date = x.CreatedDate,
                employee = x.Employee.Name,
                customer = x.Customer.Name,
                price = x.Price,
                iscurrentprice = x.IsCurrentPrice,
                product = x.Product.Name,
                type = x.Pricetype.Name,
            });
            response.Data = result;
            response.StatusMessage = "Se filtro correctamente";
            return response;
        }
        public HttpResponseModel CreatePricesForNewProducts(ProductsViewModel ProductsModel)
        {
            var response = new HttpResponseModel();
            this.CreatePriceForNewProducts(ProductsModel); // Create prices for parent product 

            foreach (var subproduct in ProductsModel.SubtypeProductList)
            {
                this.CreatePriceForNewProducts(subproduct);
            }

            return response;
        }
        private bool CreatePriceForNewProducts(ProductsViewModel ProductsModel)
        {
            var BuyPriceViewModel = new ProductPricesRequest()
            {
                productid = ProductsModel.productref.ProductId,
                pricetypeid = (int)Enums.PriceTypeEnum.Buy,
                employeeid = 29, // To do: replace for a config value
                price = ProductsModel.Buyprice,
            };
            var result = this.CreatePriceForAllCustomers(BuyPriceViewModel).WasSuccessful;
            if (result)
            {
                BuyPriceViewModel = new ProductPricesRequest()
                {
                    productid = ProductsModel.productref.ProductId,
                    pricetypeid = (int)Enums.PriceTypeEnum.Sell,
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

        public HttpResponseModel CopyPrices(CopyCustomerPricesRequest copyCustomerPricesViewModel)
        {
            var customerToName = "";
            var customerFromName = "";
            var response = new HttpResponseModel();
            var currentprice = db.ProductPrices.Include(x => x.Customer).Where(x => x.CustomerId == copyCustomerPricesViewModel.CustomerTo && x.IsCurrentPrice == true).ToList();
            foreach (var price in currentprice)
            {
                price.IsCurrentPrice = false;
                customerToName = price.Customer.Name;
            }

            var query = db.ProductPrices
                .Include(x => x.Product)
                .Include(x => x.Pricetype)
                .Include(x => x.Customer)
                .Where(x => x.CustomerId == copyCustomerPricesViewModel.CustomerFrom && x.IsCurrentPrice == true)
                .ToList();
            foreach (var prices in query)
            {
                customerFromName = prices.Customer.Name;
                var newprice = new ProductPrice()
                {
                    CreatedDate = DateTime.Now,
                    Price = prices.Price,
                    ProductId = prices.ProductId,
                    CustomerId = copyCustomerPricesViewModel.CustomerTo,
                    EmployeeId = prices.EmployeeId,
                    PricetypeId = prices.PricetypeId,
                    IsActive = true,
                    IsCurrentPrice = true,
                };
                db.ProductPrices.Add(newprice);
            };
            db.SaveChanges();
            response.StatusMessage = ($"Se copiaron los precios del cliente {customerFromName} al cliente {customerToName} correctamente");
            return response;
        }
        public HttpResponseModel CreatePriceForNewCustomer(Customer customer)
        {
            var lastestPrice = GetLatestPrice();
            var CopyPriceViewModel = new CopyCustomerPricesRequest
            {
                CustomerFrom = lastestPrice.CustomerId,
                CustomerTo = customer.CustomerId,
            };
            return this.CopyPrices(CopyPriceViewModel);
        }
        private ProductPrice GetLatestPrice()
        {
            return db.ProductPrices.Where(x => x.IsCurrentPrice == true).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

        }
    }
}