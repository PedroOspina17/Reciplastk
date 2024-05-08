using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class ProductsService
    {
        public ReciplastkContext dbReciplastk = new ReciplastkContext();

        public List<Product> GetProducts()
        {
            var allProducts = dbReciplastk.Products.ToList();
            return allProducts;
        }

        public Product GetProductId(int id)
        {
            var foundProduct = dbReciplastk.Products.Where(p => p.Id == id).FirstOrDefault();
            if (foundProduct != null)
            {
                return foundProduct;
            }
            else
            {
                return null;
            }
        }

        public bool CreateProduct(ProductsModels infoProduct)
        {
            var existProduct = dbReciplastk.Products.Where(p => p.Name == infoProduct.Name).FirstOrDefault();
            if (existProduct != null)
            {
                return false;
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

                dbReciplastk.Products.Add(newProduct);
                dbReciplastk.SaveChanges();
                return true;
            } 

        }

        public Product UpdateProduct (ProductsModels infoProduct)
        {
            var foundProduct = dbReciplastk.Products.Where(p => p.Id == infoProduct.Id).FirstOrDefault();
            if(foundProduct != null)
            {
                foundProduct.Name = infoProduct.Name;
                foundProduct.Description = infoProduct.Description;
                foundProduct.Code = infoProduct.Code;
                foundProduct.Buyprice = infoProduct.BuyPrice;
                foundProduct.Sellprice= infoProduct.SellPrice;
                foundProduct.Margin = infoProduct.Margin;
                dbReciplastk.SaveChanges();
                var productModify = dbReciplastk.Products.Where(p => p.Name == foundProduct.Name).FirstOrDefault();

                return productModify;
            }
            else {
                return null; 
            }

        }

        public bool DeleteProduct(int id)
        {
            var productFound = dbReciplastk.Products.Where(p => p.Id == id).FirstOrDefault();
            if (productFound != null)
            {
                dbReciplastk.Products.Remove(productFound);
                dbReciplastk.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
