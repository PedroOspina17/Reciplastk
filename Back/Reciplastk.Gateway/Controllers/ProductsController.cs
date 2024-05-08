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
        public ProductsService productsService = new ProductsService();

        [HttpGet("getProducts")]

        public List<Product> GetProducts()
        {
            return productsService.GetProducts();
        }

        [HttpGet("getProductId")]

        public Product GetProduct(int id)
        {
            return productsService.GetProductId(id);
        }

        [HttpPost("createProduct")]

        public bool CreateProduct(ProductsModels infoProducts)
        {
            return productsService.CreateProduct(infoProducts);
        }

        [HttpPost("updateProduct")]

        public Product UpdateProduct(ProductsModels infoProducts)
        {
            return productsService.UpdateProduct(infoProducts);
        }

        [HttpDelete("deleteProduct")]
        public bool DeleteProduct(int id)
        {
            return productsService.DeleteProduct(id);
        }


    }
}
