using Azure;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class ProductsService
    {

        private readonly ReciplastkContext db;

        public ProductsService( ReciplastkContext dbReciplastk)
        {
            this.db = dbReciplastk;
        }
        public HttpResponseModel GetProducts()
        {
            var productsInfo = db.Products.ToList();
            var response = new HttpResponseModel();
            if(productsInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The information provided is not correct.";
            }
            else
            {
                response.StatusCode = 200;
                response.WasSuccessful = true;
                response.StatusMessage = "the product list was found.";
                response.Data = productsInfo;
            }
            return response;
        }

        public HttpResponseModel GetProductId(int id)
        {
            var productInfo = db.Products.Where(p => p.Id == id).FirstOrDefault();
            var response = new HttpResponseModel();
            if (productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The product is not found.";
            }
            else
            {
                response.StatusCode = 200;
                response.WasSuccessful = true;
                response.StatusMessage = "The producto was found.";
                response.Data = productInfo;
            }
                return response;
        }

        public HttpResponseModel CreateProduct(ProductsModels infoProduct)
        {
            var productInfo = db.Products.Where(p => p.Name == infoProduct.Name).FirstOrDefault();
            var response = new HttpResponseModel();
            if (productInfo != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The product exists in the database.";
            }
            else
            {
                var newProduct = new Product();
                newProduct.Name = infoProduct.Name;
                newProduct.Description = infoProduct.Description;
                newProduct.Code = infoProduct.Code;
                newProduct.Buyprice = infoProduct.BuyPrice;
                newProduct.Sellprice = infoProduct.SellPrice;
                newProduct.Margin = infoProduct.Margin;

                db.Products.Add(newProduct);
                db.SaveChanges();
                response.StatusCode = 200;
                response.WasSuccessful = true;
                response.StatusMessage = "the product was created successfully. ";
                response.Data = newProduct;
            }
            return response;

        }

        public HttpResponseModel UpdateProduct (ProductsModels infoProduct)
        {
            var productInfo = db.Products.Where(p => p.Id == infoProduct.Id).FirstOrDefault();
            var response = new HttpResponseModel();

            if(productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The producto was no found. "; 
            } else {
                productInfo.Name = infoProduct.Name;
                productInfo.Description = infoProduct.Description;
                productInfo.Code = infoProduct.Code;
                productInfo.Buyprice = infoProduct.BuyPrice;
                productInfo.Sellprice = infoProduct.SellPrice;
                productInfo.Margin = infoProduct.Margin;
                db.SaveChanges();
                var productModify = db.Products.Where(p => p.Name == infoProduct.Name).FirstOrDefault();

                response.StatusCode = 200;
                response.WasSuccessful = true;
                response.StatusMessage = "The Product was modified successfully.";
                response.Data = productModify;
            }
            return response;

        }

        public HttpResponseModel DeleteProduct(int id)
        {
            var productFound = db.Products.Where(p => p.Id == id).FirstOrDefault();
            var response = new HttpResponseModel();
            if (productFound == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The product was not found.";
                
            } else {
                db.Products.Remove(productFound);
                db.SaveChanges();
                response.StatusCode = 200;
                response.WasSuccessful = true;
                response.StatusMessage = "The product was deleted successfully.";
                response.Data = productFound;
            }
            return response;
        }

    }
}
