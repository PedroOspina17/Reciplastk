using Azure;
using Microsoft.EntityFrameworkCore;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
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

        public HttpResponseModel GetCurrentPrice(int productid, int pricetypeid)
        {
            var lastestPrice = GetLatestPrice(); // Gets latest customer a customer
            var response = new HttpResponseModel();
            var query = db.Productprices
                .Where(x => x.Productid == productid && x.Customerid == lastestPrice.Customerid && x.Pricetypeid == pricetypeid && x.Iscurrentprice == true)
                .OrderByDescending(x => x.Creationdate)
                .Select(y => y.Price).FirstOrDefault();

            response.Data = query;
            return response;
        }

        public HttpResponseModel GetCurrentPrice(int productid, int customerid, int pricetypeid)
        {
            var response = new HttpResponseModel();
            var query = db.Productprices
                .Where(x => x.Productid == productid && x.Customerid == customerid && x.Pricetypeid == pricetypeid && x.Iscurrentprice == true)
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
                var query = db.Productprices
                    .Where(x => x.Productid == productPricesViewModel.productid && x.Customerid == productPricesViewModel.customerid.Value && x.Pricetypeid == productPricesViewModel.pricetypeid && x.Iscurrentprice == true).FirstOrDefault();
                query.Iscurrentprice = false;
                var newObject = new Productprice();
                newObject.Productid = productPricesViewModel.productid;
                newObject.Customerid = productPricesViewModel.customerid.Value;
                newObject.Pricetypeid = productPricesViewModel.pricetypeid;
                newObject.Employeeid = 29; ; // To do: get from logged in user
                newObject.Price = productPricesViewModel.price;
                newObject.Creationdate = DateTime.Now;
                newObject.Isactive = true;
                newObject.Iscurrentprice = true;
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
            List<Customer> customers;
            if (productPricesViewModel.pricetypeid == 1)
            {
                customers = db.Customers.Where(x => x.Isactive == true && x.Customertypeid == (int)Enums.CustomerTypeEnum.provider).ToList();
            }
            else
            {
                customers = db.Customers.Where(x => x.Isactive == true && x.Customertypeid == (int)Enums.CustomerTypeEnum.customer).ToList();
            }
            var query = db.Productprices.Where(x => x.Productid == productPricesViewModel.productid && x.Pricetypeid == productPricesViewModel.pricetypeid && x.Iscurrentprice == true).ToList();
            query.ForEach(x => x.Iscurrentprice = false);
            foreach (var customer in customers)
            {
                //customer.Iscurrentprice = false;
                var currentprice = (double)this.GetCurrentPrice(productPricesViewModel.productid, customer.Customerid, productPricesViewModel.pricetypeid).Data;
                var newObject = new Productprice();
                newObject.Productid = productPricesViewModel.productid;
                newObject.Customerid = customer.Customerid;
                newObject.Pricetypeid = productPricesViewModel.pricetypeid;
                newObject.Employeeid = 29; ; // To do: get from logged in user
                newObject.Price = currentprice + productPricesViewModel.price;
                newObject.Creationdate = DateTime.Now;
                newObject.Isactive = true;
                newObject.Iscurrentprice = true;
                db.Productprices.Add(newObject);
            }
            db.SaveChanges();
            response.StatusMessage = "Se creo el precio del producto correctamente";
            return response;

        }
        public HttpResponseModel Filter(FilterViewModel filterViewModel)
        {
            var response = new HttpResponseModel();
            var query = db.Productprices.Where(x => x.Customer.Isactive == true);
            if (filterViewModel.customerid != null && filterViewModel.customerid != -1)
            {
                query = query.Where(x => x.Customerid == filterViewModel.customerid);
            };
            if (filterViewModel.productid != null && filterViewModel.productid != -1)
            {
                query = query.Where(x => x.Productid == filterViewModel.productid);
            };
            if (filterViewModel.pricetypeid != null && filterViewModel.pricetypeid != -1)
            {
                query = query.Where(x => x.Pricetypeid == filterViewModel.pricetypeid);
            };
            if (filterViewModel.ShowHistory != null && filterViewModel.ShowHistory == false)
            {
                query = query.Where(x => x.Iscurrentprice == !filterViewModel.ShowHistory);
            }
            var result = query
            .OrderByDescending(x => x.Iscurrentprice)
            .ThenByDescending(x => x.Creationdate)
            .ThenByDescending(x => x.Customerid)
            .Select(x => new ProductPriceInnerParams
            {
                date = x.Creationdate,
                employee = x.Employee.Name,
                customer = x.Customer.Name,
                price = x.Price,
                iscurrentprice = x.Iscurrentprice,
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

        public HttpResponseModel CopyPrices(CopyCustomerPricesViewModel copyCustomerPricesViewModel)
        {
            var customerToName = "";
            var customerFromName = "";
            var response = new HttpResponseModel();
            var currentprice = db.Productprices.Include(x => x.Customer).Where(x => x.Customerid == copyCustomerPricesViewModel.CustomerTo && x.Iscurrentprice == true).ToList();
            foreach (var price in currentprice)
            {
                price.Iscurrentprice = false;
                customerToName = price.Customer.Name;
            }

            var query = db.Productprices
                .Include(x => x.Product)
                .Include(x => x.Pricetype)
                .Include(x => x.Customer)
                .Where(x => x.Customerid == copyCustomerPricesViewModel.CustomerFrom && x.Iscurrentprice == true)
                .ToList();
            foreach (var prices in query)
            {
                customerFromName = prices.Customer.Name;
                var newprice = new Productprice()
                {
                    Creationdate = DateTime.Now,
                    Price = prices.Price,
                    Productid = prices.Productid,
                    Customerid = copyCustomerPricesViewModel.CustomerTo,
                    Employeeid = prices.Employeeid,
                    Pricetypeid = prices.Pricetypeid,
                    Isactive = true,
                    Iscurrentprice = true,
                };
                db.Productprices.Add(newprice);
            };
            db.SaveChanges();
            response.StatusMessage = ($"Se copiaron los precios del cliente {customerFromName} al cliente {customerToName} correctamente");
            return response;
        }
        public HttpResponseModel CreatePriceForNewCustomer(Customer customer)
        {
            var lastestPrice = GetLatestPrice();
            var CopyPriceViewModel = new CopyCustomerPricesViewModel
            {
                CustomerFrom = lastestPrice.Customerid,
                CustomerTo = customer.Customerid,
            };
            return this.CopyPrices(CopyPriceViewModel);
        }
        private Productprice GetLatestPrice()
        {
            return db.Productprices.Where(x => x.Iscurrentprice == true).OrderByDescending(x => x.Creationdate).FirstOrDefault();

        }
    }
}