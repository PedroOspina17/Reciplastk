using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using System.Linq;

namespace Reciplastk.Gateway.Services
{
    public class ProductsService
    {

        private readonly ReciplastkContext db;
        private readonly ProductPricesService priceService;

        public ProductsService(ReciplastkContext dbReciplastk, ProductPricesService priceService)
        {
            this.db = dbReciplastk;
            this.priceService = priceService;
        }
        private Product FindById(int id)
        {
            var product = db.Products.Include(x => x.InverseParent).Where(p => p.Productid == id && p.Isactive).FirstOrDefault();

            return product;
        }

        private HttpResponseModel Validate(ProductsViewModel ProductsModel)
        {
            var response = new HttpResponseModel();

            if (ProductsModel == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "La información es invalida.";
                return response;
            }

            if (ProductsModel.Shortname == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El nombre es requerido.";
                return response;

            }
            else
            {
                var product = db.Products.Where(p => p.Shortname.ToLower().Trim() == ProductsModel.Shortname.ToLower().Trim()).FirstOrDefault();

                if (product != null)
                {
                    response.WasSuccessful = false;
                    response.StatusMessage = " El nombre del producto ya existe.";
                    return response;
                }
            }

            if (ProductsModel.Code == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El códgio es requerido.";
                return response;

            }
            else
            {
                var product = db.Products.Where(p => p.Code.ToLower().Trim() == ProductsModel.Code.ToLower().Trim()).FirstOrDefault();
                if (product != null)
                {

                    response.WasSuccessful = false;
                    response.StatusMessage = " Ya existe un producto con el mismo código en la base de datos.";
                    return response;
                }
            }

            foreach (var product in ProductsModel.SubtypeProductList) // If contains subproducts validate them one by one.
            {
                response = Validate(product);
                if (response.WasSuccessful == false)
                {
                    return response;
                }

            }


            response.WasSuccessful = true;
            return response;

        }
        public HttpResponseModel GetAll()
        {
            var productsInfo = db.Products.Where(p => p.Isactive).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = productsInfo;

            return response;
        }

        public HttpResponseModel GetMainProducts()
        {
            var parentProdcutIds = db.Products.Where(p => p.Isactive && p.Parentid != null).Select(x => x.Parentid).ToList();
            var productsMain = db.Products.Where(p => parentProdcutIds.Contains( p.Productid ) ).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = productsMain;
            return response;
        }
        public HttpResponseModel GetSpecificProducts()
        {
            var productsMain = db.Products.Where(p => p.Isactive && p.Issubtype == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = productsMain;
            return response;
        }
        public HttpResponseModel GetById(int id)
        {
            var productInfo = FindById(id);
            productInfo.InverseParent = productInfo.InverseParent.Where(x => x.Isactive).ToList();

            var response = new HttpResponseModel();
            if (productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El producto con el Id enviado, no fue encontrado.";
            }
            else
            {
                response.WasSuccessful = true;
                response.Data = productInfo;
            }
            return response;
        }

        public HttpResponseModel GetByParentid(int id)
        {
            var productInfo = db.Products.Where(p => p.Parentid == id && p.Isactive).ToList();
            var response = new HttpResponseModel();

            response.WasSuccessful = true;
            response.Data = productInfo;

            return response;
        }

        public HttpResponseModel Create(ProductsViewModel ProductsModel)
        {
            var response = Validate(ProductsModel);

            if (response.WasSuccessful)
            {
                var parentProduct = new Product();
                parentProduct.Shortname = ProductsModel.Shortname;
                parentProduct.Name = ProductsModel.Name;
                parentProduct.Description = ProductsModel.Description;
                parentProduct.Code = ProductsModel.Code;
                parentProduct.Issubtype = false;
                parentProduct.Isactive = true;

                db.Products.Add(parentProduct);
                ProductsModel.productref = parentProduct;
                foreach (var subproduct in ProductsModel.SubtypeProductList)
                {
                    var newSubproduct = new Product();
                    newSubproduct.Parent = parentProduct;
                    newSubproduct.Name = subproduct.Name;
                    newSubproduct.Shortname = subproduct.Shortname;
                    newSubproduct.Description = subproduct.Description;
                    newSubproduct.Code = subproduct.Code;
                    newSubproduct.Isactive = true;
                    newSubproduct.Issubtype = true;
                    db.Products.Add(newSubproduct);
                    subproduct.productref = newSubproduct;
                }

                db.SaveChanges();
                this.priceService.CreatePricesForNewProducts(ProductsModel);
                response.WasSuccessful = true;
                response.StatusMessage = "El producto fue Creado exitosamente. ";
            }
            return response;
        }

        public HttpResponseModel Update(ProductsViewModel ProductsModel)
        {
            var id = ProductsModel.Productid ?? -1;
            var productInfo = FindById(id);
            var response = new HttpResponseModel();

            if (productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El producto con el id enviado no fue encontrado en la base de datos.";
            }
            else
            {
                productInfo.Name = ProductsModel.Name;
                productInfo.Description = ProductsModel.Description;
                productInfo.Code = ProductsModel.Code;

                foreach (var subtype in ProductsModel.SubtypeProductList)
                {
                    if (subtype.Productid == null || subtype.Productid <= 0)
                    {
                        var newSubproduct = new Product
                        {
                            Parent = productInfo, 
                            Name = subtype.Name,
                            Shortname = subtype.Shortname,
                            Description = subtype.Description,
                            Code = subtype.Code,
                            Isactive = true,
                            Issubtype = true
                        };
                        db.Products.Add(newSubproduct);
                    }
                    else
                    {
                        var existingSubproduct = db.Products.Where(p => p.Productid == subtype.Productid).FirstOrDefault();
                        if (existingSubproduct != null)
                        {
                            existingSubproduct.Name = subtype.Name;
                            existingSubproduct.Shortname = subtype.Shortname;
                            existingSubproduct.Description = subtype.Description;
                            existingSubproduct.Code = subtype.Code;
                        }
                    }
                }
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El producto fue modificado exitosamente.";
            }
            return response;
        }

        public HttpResponseModel Delete(int id)
        {
            var response = new HttpResponseModel();
            var productFound = FindById(id);

            if (productFound != null)
            {
                productFound.Isactive = false;
                db.SaveChanges();

                response.WasSuccessful = true;
                response.Data = productFound;
                response.StatusMessage = "El producto fue creado exitosamente.";

            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El producto no existe en la Base de datos.";
            }
            return response;
        }

    }
}
