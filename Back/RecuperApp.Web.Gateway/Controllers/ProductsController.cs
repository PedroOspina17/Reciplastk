using System.Data;
using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductsService productsService;

        public ProductsController( IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("GetAll")]

        public async Task<HttpResponseModel> GetAll()
        {
            var result = await productsService.GetAll();
            return new HttpResponseModel(result);
        }

        [HttpGet("GetMainProducts")]

        public async Task<HttpResponseModel> GetMainProducts()
        {
            var result = await productsService.GetMainProducts();
            return new HttpResponseModel(result);

        }

        [HttpGet("GetSpecificProducts")]
        public async Task<HttpResponseModel> GetSpecificProducts() {
            var result = await productsService.GetSpecificProducts();
            return new HttpResponseModel(result);

        }

        [HttpGet("GetById")]
        public async Task<HttpResponseModel> GetById(int id)
        {
            var result = await productsService.GetById(id);
            return new HttpResponseModel(result);

        }

        [HttpGet("GetByParentid")]

        public async Task<HttpResponseModel> GetByParentid(int id)
        {
            var result = await productsService.GetChildren(id);
            return new HttpResponseModel(result);

        }

        [HttpPost("Create")]

        public async Task<HttpResponseModel> Create(ProductsRequest productModel)
        {
            var result = await productsService.Create(productModel);
            return new HttpResponseModel(result, $"Se creó el producto {result.ShortName} exitosamente, con id #{result.Id}");
        }
        [HttpPut("Update")]

        public async Task<HttpResponseModel> Update(ProductsRequest productModel)
        {
            var result = await productsService.Update(productModel);
            return new HttpResponseModel(result, $"Se modificó el producto ${result.ShortName} exitosamente");
        }

        [HttpDelete("Delete")]
        public async Task<HttpResponseModel> Delete(int id)
        {
            var result = await productsService.Delete(id);
            return new HttpResponseModel($"Se eliminó el producto ${result.ShortName} exitosamente");

        }
    }
}
