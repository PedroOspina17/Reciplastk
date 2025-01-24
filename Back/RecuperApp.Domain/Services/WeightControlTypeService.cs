using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class WeightControlTypeService
    {
        private readonly ReciplastkContext db;
        public WeightControlTypeService (ReciplastkContext db)
        {
            this.db = db;
        }
        private WeightControlType ById (int id)
        {
            var controltype = db.WeightControlTypes.Where(x => x.IsActive && x.WeightControlTypeId == id).FirstOrDefault();
            return controltype;
        }
        public HttpResponseModel GetAll()
        {
            var controltype = db.WeightControlTypes.Where(x=> x.IsActive == true).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = controltype
            };
            return response;
        }
        public HttpResponseModel GetById(int id) {
            var response = new HttpResponseModel();
            var controltype = ById(id);
            if (response != null)
            {
                response.WasSuccessful = true;
                response.Data = controltype;
            }else { 
                response.WasSuccessful = false;
                response.StatusMessage = "El id del tipo de control de peso no existe";
            }
            return response;
        }
        public HttpResponseModel Create(WeightControlTypeRequest weightControlTypeViewModel)
        {
            var response = new HttpResponseModel();
            var newcontroltype = new WeightControlType
            {
                Name = weightControlTypeViewModel.Name,
                Description = weightControlTypeViewModel.Description,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            db.WeightControlTypes.Add(newcontroltype);
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El tipo de control de peso se creó exitosamente";
            return response;
        }

        public HttpResponseModel Update(WeightControlTypeRequest weightControlTypeViewModel)
        {
            var controltype = ById(weightControlTypeViewModel.WeightControlTypeId);
            var response = new HttpResponseModel();
            if (controltype != null)
            {
                controltype.Name = weightControlTypeViewModel.Name;
                controltype.Description = weightControlTypeViewModel.Description;
                controltype.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de control de peso se actualizo exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro el tipo de control de peso con el id indicado";
            }
                return response;
        }
        public HttpResponseModel Delete(int id)
        {
            var response = new HttpResponseModel();
            var controltype = ById(id);
            if (controltype != null)
            {
                controltype.IsActive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de control de peso se elimino exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de control de peso con el id indicado";
            }
            return response;
        }
    }
}
