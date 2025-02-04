using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecuperApp.Common.Exceptions;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{
    public class ProductsService : ApplicationService<Product>, IProductsService
    {
        private readonly ProductPricesService priceService;
        private readonly ILogger<ProductsService> logger;

        public ProductsService(IApplicationRepository<Product> applicationRepository, ProductPricesService priceService, IMapper mapper, ILogger<ProductsService> logger) : base(applicationRepository, mapper)
        {
            this.priceService = priceService;
            this.logger = logger;
        }

        public async Task<List<Product>> GetMainProducts()
        {
            var parentProducts = await applicationRepository.GetByParamAsync(p => p.ParentId != null);
            var parentProductIds = parentProducts.Select(x=> x.ParentId).Distinct().ToList();
            var productsMain = await applicationRepository.GetByParamAsync(p => parentProductIds.Contains(p.Id));
            return productsMain;
        }
        public async Task<List<Product>> GetSpecificProducts()
        {
            var products = await applicationRepository.GetByParamAsync(p => p.IsSubtype == true);
            return products;
        }

        public async Task<List<Product>> GetChildren(int parentId)
        {
            var productInfo = await applicationRepository.GetByParamAsync(p => p.ParentId == parentId);
            return productInfo;
        }

        public async Task<Product> Create(ProductsRequest productsModel)
        {
            var response = await ValidateEntity(productsModel);

            var parentProduct = mapper.Map<Product>(productsModel);
            parentProduct.IsSubtype = false;
            parentProduct.SubProducts = productsModel.SubtypeProductList?.Count > 0 ? new List<Product>() : null;
            productsModel.ProductRef = parentProduct;
            foreach (var currentSubproduct in productsModel.SubtypeProductList)
            {
                var subproduct = mapper.Map<Product>(currentSubproduct);
                subproduct.IsSubtype = true;
                parentProduct.SubProducts.Add(subproduct);
                currentSubproduct.ProductRef = subproduct;
            }
            var result = await applicationRepository.CreateAsync(parentProduct);
            //var parentProduct = new Product
            //{
            //    ShortName = ProductsModel.ShortName,
            //    Name = ProductsModel.Name,
            //    Description = ProductsModel.Description,
            //    Code = ProductsModel.Code,
            //    IsSubtype = false,
            //    IsActive = true
            //};
            //productsModel.ProductRef = parentProduct;
            //db.Products.Add(parentProduct);
            //foreach (var subproduct in ProductsModel.SubtypeProductList)
            //{
            //    var newSubproduct = new Product
            //    {
            //        Parent = parentProduct,
            //        Name = subproduct.Name,
            //        ShortName = subproduct.ShortName,
            //        Description = subproduct.Description,
            //        Code = subproduct.Code,
            //        IsActive = true,
            //        IsSubtype = true
            //    };
            //    db.Products.Add(newSubproduct);
            //    subproduct.ProductRef = newSubproduct;
            //}

            //db.SaveChanges();

            this.priceService.CreatePricesForNewProducts(productsModel);

            return result;

        }

        public async Task<Product> Update(ProductsRequest productsModel)
        {
            var id = productsModel.ProductId ?? -1;
            var productInfo = await GetById(id);

            productInfo = mapper.Map(productsModel, productInfo);

            //productInfo.Name = ProductsModel.Name;
            //productInfo.Description = ProductsModel.Description;
            //productInfo.Code = ProductsModel.Code;

            foreach (var subtype in productsModel.SubtypeProductList)
            {
                if (subtype.ProductId == null || subtype.ProductId <= 0)
                {
                    if (productInfo.SubProducts == null)
                        productInfo.SubProducts = new List<Product>();

                    var newSubproduct = mapper.Map(productsModel, productInfo);
                    newSubproduct.IsSubtype = true;
                    productInfo.SubProducts.Add(newSubproduct);
                    //var newSubproduct = new Product
                    //{
                    //    Parent = productInfo,
                    //    Name = subtype.Name,
                    //    ShortName = subtype.ShortName,
                    //    Description = subtype.Description,
                    //    Code = subtype.Code,
                    //    IsActive = true,
                    //    IsSubtype = true
                    //};
                    //db.Products.Add(newSubproduct);
                }
            }
            //db.SaveChanges();
            await applicationRepository.UpdateAsync(productInfo);
            return productInfo;
        }


        protected async Task<bool> ValidateEntity(ProductsRequest productsModel)
        {
            if (productsModel == null)
            {
                logger.LogWarning("The product model request was null, this is probable an error.");
                throw new CustomValidationsException("No se recibió información para guardar. Por favor intente de nuevo, sí el error persiste comuniquese con el administrador del sistema.", alreadyLoggedException: true);
            }

            if (productsModel.ShortName == null)
            {
                throw new CustomValidationsException("El nombre corto del producto es requerido.");
            }
            else
            {
                var product = await applicationRepository.FindByParamAsync(p => p.ShortName.ToLower().Trim() == productsModel.ShortName.ToLower().Trim());

                if (product != null)
                {
                    throw new CustomValidationsException("El nombre corto del producto ya existe y este debe ser único.");
                }
            }

            if (productsModel.Code == null)
            {
                throw new CustomValidationsException("El código del producto es requerido.");
            }
            else
            {
                var product = await applicationRepository.FindByParamAsync(p => p.Code.ToLower().Trim() == productsModel.Code.ToLower().Trim());
                if (product != null)
                {
                    throw new CustomValidationsException("El código del producto ya existe y este debe ser único.");

                }
            }

            foreach (var subProduct in productsModel.SubtypeProductList) // If contains subproducts validate them one by one.
            {
                if (await ValidateEntity(subProduct) == false)
                {
                    throw new CustomValidationsException("La información de los sobproductos es incorrecta. Por favor verifíquela e intente de nuevo.");
                }

            }
            return true;

        }


    }
}
