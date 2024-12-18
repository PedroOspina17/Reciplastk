using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPricesController : ControllerBase
    {
        private readonly ProductPricesService productPricesService;
        public ProductPricesController(ProductPricesService productPricesService)
        {
            this.productPricesService = productPricesService;
        }
        [HttpGet("GetAllPriceTypes")]
        public HttpResponseModel GetAllPriceTypes()
        {
            return this.productPricesService.GetAllPriceTypes();
        }
        [HttpGet("GetAllProductPrices")]
        public HttpResponseModel GetAllProductPrices()
        {
            return this.productPricesService.GetAllProductPrices();
        }

        [HttpGet("GetPriceTypesById")]
        public HttpResponseModel GetPriceTypesById(int id)
        {
            return this.productPricesService.GetPriceTypesById(id);
        }
        [HttpGet("GetProductPricesById")]
        public HttpResponseModel GetProductPricesById(int id)
        {
            return this.productPricesService.GetProductPricesById(id);
        }

        [HttpPost("CreatePriceTypes")]
        public HttpResponseModel CreatePriceTypes(PriceTypeViewModel priceTypeViewModel) {
            return this.productPricesService.CreatePriceTypes(priceTypeViewModel);
        }

        [HttpPost("CreateProductPrices")]
        public HttpResponseModel CreateProductPrices(ProductPricesViewModel productPricesViewModel) {
           return this.productPricesService.CreateProductPrices(productPricesViewModel);
        }
        [HttpPost("Filter")]
        public HttpResponseModel Filter(FilterViewModel filterViewModel)
        {
            return this.productPricesService.Filter(filterViewModel);
        }
        [HttpGet("GetCurrentPrice")]
        public HttpResponseModel GetCurrentPrice(int productid, int customerid, int productpricetypeid) {
            return this.productPricesService.GetCurrentPrice(productid,customerid, productpricetypeid);
        }
        [HttpPost("CopyPrices")]
        public HttpResponseModel CopyPrices(CopyCustomerPricesViewModel copyCustomerPricesViewModel)
        {
            return this.productPricesService.CopyPrices(copyCustomerPricesViewModel);
        }
        // call getcurrentprices where we were using default prices
    }
}
