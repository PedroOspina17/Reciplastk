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

        [HttpGet("GetAll")]

        public HttpResponseModel GetAll()
        {
            return productsService.GetAll();
        }

        [HttpGet("GetMainProducts")]

        public HttpResponseModel GetMainProducts()
        {
            return productsService.GetMainProducts();
        }

        [HttpGet("GetSpecificProducts")]
        public HttpResponseModel GetSpecificProducts() {
            return productsService.GetSpecificProducts();
        }

        [HttpGet("GetById")]
        public HttpResponseModel GetById(int id)
        {
            return productsService.GetById(id);
        }

        [HttpGet("GetByParentid")]

        public HttpResponseModel GetByParentid(int id)
        {
            return productsService.GetByParentid(id);
        }

        [HttpPost("Create")]

        public HttpResponseModel Create(ProductsViewModel productModel)
        {
            return productsService.Create(productModel);
        }

        [HttpPut("Update")]

        public HttpResponseModel Update(ProductsViewModel productModel)
        {
            return productsService.Update(productModel);
        }

        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int id)
        {
            return productsService.Delete(id);
        }


    }
}
