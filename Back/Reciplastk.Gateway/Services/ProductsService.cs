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
        private Product FindbyId(int id)
        {
            var product = db.Products.Where(p => p.Productid == id && p.Isactive  == true ).FirstOrDefault();

            return product;
        }
        public HttpResponseModel GetAll()
        {
            var productsInfo = db.Products.Where(p => p.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = productsInfo;
           
            return response;
        }
        public HttpResponseModel GetById(int id)
        {
            var productInfo = FindbyId(id);
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

        public HttpResponseModel GetByParentid (int id)
        {
            var productInfo = db.Products.Where(p => p.Parentid == id && p.Isactive == true).ToList();
            var response = new HttpResponseModel();

            response.WasSuccessful = true;
            response.Data = productInfo;

            return response;
        }

        public HttpResponseModel Create(ProductsViewModel ProductsModel)
        {
            var product = db.Products.Where(p => p.Name.ToLower().Trim() == ProductsModel.Name.ToLower().Trim()).FirstOrDefault();
            var response = new HttpResponseModel();
            if (product != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El producto no puede ser creado, ya existe en la Base de Datos.";
            }
            else
            {
                var parentProduct = new Product();
                parentProduct.Shortname = ProductsModel.Shortname;
                parentProduct.Name = ProductsModel.Name;
                parentProduct.Description = ProductsModel.Description;
                parentProduct.Code = ProductsModel.Code;
                parentProduct.Buyprice = ProductsModel.Buyprice;
                parentProduct.Sellprice = ProductsModel.Sellprice;
                parentProduct.Margin = ProductsModel.Margin;
                parentProduct.Issubtype = ProductsModel.Issubtype;
                parentProduct.Parentid = 0;
                parentProduct.Isactive = true;
        
                db.Products.Add(parentProduct);
              
                if (ProductsModel.Issubtype == true) {
                    
                    var codeSubtype = 0;
                    codeSubtype += 1;
                    foreach (var subproduct in ProductsModel.SubtypeProductList)
                    {
                        var newSubproduct = new Product();
                        newSubproduct.Name = parentProduct.Name + " - " + ProductsModel.Name;
                        newSubproduct.Shortname = parentProduct.Shortname + " - " + ProductsModel.Name;
                        newSubproduct.Description = parentProduct.Description;
                        newSubproduct.Code = parentProduct.Code + codeSubtype; 
                        newSubproduct.Buyprice = parentProduct.Buyprice;
                        newSubproduct.Sellprice = ProductsModel.Sellprice;
                        newSubproduct.Margin = parentProduct.Margin;
                        newSubproduct.Parentid = parentProduct.Productid;
                        db.Products.Add(newSubproduct);
                    }
                }
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El producto fue Creado exitosamente. ";

            }
            return response;

        }

        public HttpResponseModel Update(ProductsViewModel ProductsModel)
        {
            var productInfo = FindbyId(ProductsModel.Productid);

            var response = new HttpResponseModel();

            if(productInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El producto no fue encontrado en la base de datos. "; 
            } else {
                productInfo.Shortname = ProductsModel.Shortname;
                productInfo.Name = ProductsModel.Name;
                productInfo.Description = ProductsModel.Description;
                productInfo.Code = ProductsModel.Code;
                productInfo.Buyprice = ProductsModel.Buyprice;
                productInfo.Sellprice = ProductsModel.Sellprice;
                productInfo.Margin = ProductsModel.Margin;
                productInfo.Issubtype = ProductsModel.Issubtype;
                               
                db.SaveChanges();
                  
                response.WasSuccessful = true;
                response.StatusMessage = "El producto fue modificado exitosamente. ";
            }
            return response;

        }

        public HttpResponseModel Delete(int id)
        {
            var response = new HttpResponseModel();
            var productFound = FindbyId(id);
           
            if (productFound != null)
            {
                productFound.Isactive = false;
                db.SaveChanges();

                response.WasSuccessful = true;
                response.Data = productFound;
                response.StatusMessage = "El producto fue creado exitosamente.";

            } else {
                response.WasSuccessful = false;
                response.StatusMessage = "El producto no existe en la Base de datos.";
            }
            return response;
        }

    }
}
