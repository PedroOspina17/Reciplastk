using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IProductsService : IApplicationService<Product>
    {
        Task<Product> Create(ProductsRequest productsModel);
        Task<List<Product>> GetChildren(int parentId);
        Task<List<Product>> GetMainProducts();
        Task<List<Product>> GetSpecificProducts();
        Task<Product> Update(ProductsRequest productsModel);
    }
}