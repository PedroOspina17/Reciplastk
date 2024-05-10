using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly ProductsService productsService;

        public ProductsController( ProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("getProducts")]

        public HttpResponseModel GetProducts()
        {
            return productsService.GetProducts();
        }

        [HttpGet("getProductId")]

        public HttpResponseModel GetProduct(int id)
        {
            return productsService.GetProductId(id);
        }

        [HttpPost("createProduct")]

        public HttpResponseModel CreateProduct(ProductsModels infoProducts)
        {
            return productsService.CreateProduct(infoProducts);
        }

        [HttpPost("updateProduct")]

        public HttpResponseModel UpdateProduct(ProductsModels infoProducts)
        {
            return productsService.UpdateProduct(infoProducts);
        }

        [HttpDelete("deleteProduct")]
        public HttpResponseModel DeleteProduct(int id)
        {
            return productsService.DeleteProduct(id);
        }


    }
}
