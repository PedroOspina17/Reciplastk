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
        private Product GetProductbyId(int id)
        {
            var product = db.Products.Where(p => p.Productid == id).FirstOrDefault();

            return product;
        }
        public HttpResponseModel GetProducts()
        {
            var productsInfo = db.Products.ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = productsInfo;
           
            return response;
        }
        public HttpResponseModel GetProductId(int id)
        {
            var productInfo = GetProductbyId(id);
            var response = new HttpResponseModel();
            if (productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The product is not found.";
            }
            else
            {
                response.WasSuccessful = true;
                response.Data = productInfo;
            }
                return response;
        }

        public HttpResponseModel GetProductsbyParentid (int id)
        {
            var productInfo = db.Products.Where(p => p.Parentid == id).ToList();
            var response = new HttpResponseModel();

            response.WasSuccessful = true;
            response.Data = productInfo;

            return response;
        }

        public HttpResponseModel CreateProduct(ProductsViewModel infoProduct)
        {
            var product = db.Products.Where(p => p.Name == infoProduct.Name).FirstOrDefault();
            var response = new HttpResponseModel();
            if (product != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The product exists in the database.";
            }
            else
            {
                var parentProduct = new Product();
                parentProduct.Shortname = infoProduct.ShortName;
                parentProduct.Name = infoProduct.Name;
                parentProduct.Description = infoProduct.Description;
                parentProduct.Code = infoProduct.Code;
                parentProduct.Buyprice = infoProduct.BuyPrice;
                parentProduct.Sellprice = infoProduct.SellPrice;
                parentProduct.Margin = infoProduct.Margin;
                parentProduct.Issubtype = infoProduct.IsSubtype;
        
                db.Products.Add(parentProduct);
              
                if (infoProduct.IsSubtype == true) {
                    
                    var codeSubtype = 0;
                    codeSubtype += codeSubtype;
                    foreach (var subproduct in infoProduct.SubtypeProductList)
                    {
                        var newSubproduct = new Product();
                        newSubproduct.Name = parentProduct.Name + " - " + infoProduct.Name;
                        newSubproduct.Shortname = parentProduct.Shortname + " - " + infoProduct.Name;
                        newSubproduct.Description = parentProduct.Description;
                        newSubproduct.Code = parentProduct.Code + codeSubtype; // consecutivo
                        newSubproduct.Buyprice = parentProduct.Buyprice;
                        newSubproduct.Sellprice = infoProduct.SellPrice;
                        newSubproduct.Margin = parentProduct.Margin;
                        newSubproduct.Parentid = parentProduct.Productid;
                        db.Products.Add(newSubproduct);
                    }
                }
                db.SaveChanges();
            }
            return response;

        }

        public HttpResponseModel UpdateProduct (ProductsViewModel infoProduct)
        {
            var productInfo = db.Products.Where(p => p.Productid == infoProduct.ProductId).FirstOrDefault();

            var response = new HttpResponseModel();

            if(productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The producto was no found. "; 
            } else {
                productInfo.Shortname = infoProduct.ShortName;
                productInfo.Name = infoProduct.Name;
                productInfo.Description = infoProduct.Description;
                productInfo.Code = infoProduct.Code;
                productInfo.Buyprice = infoProduct.BuyPrice;
                productInfo.Sellprice = infoProduct.SellPrice;
                productInfo.Margin = infoProduct.Margin;
                productInfo.Issubtype = infoProduct.IsSubtype;
               
                db.SaveChanges();
                var productModify = db.Products.Where(p => p.Name == infoProduct.Name).FirstOrDefault();
                                
                response.WasSuccessful = true;
                response.Data = productModify;
            }
            return response;

        }

        public HttpResponseModel DeleteProduct(int id)
        {
            var productFound = GetProductbyId(id);
            var response = new HttpResponseModel();
            if (productFound == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The product was not found.";
                
            } else {
                db.Products.Remove(productFound);
                db.SaveChanges();
              
                response.WasSuccessful = true;
                response.Data = productFound;
            }
            return response;
        }

    }
}
