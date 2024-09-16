using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class WeightControlTypeService
    {
        private readonly ReciplastkContext db;
        public WeightControlTypeService (ReciplastkContext db)
        {
            this.db = db;
        }
        private Weightcontroltype ById (int id)
        {
            var controltype = db.Weightcontroltypes.Where(x => x.Isactive && x.Weightcontroltypeid == id).FirstOrDefault();
            return controltype;
        }
        public HttpResponseModel GetAll()
        {
            var controltype = db.Weightcontroltypes.Where(x=> x.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = controltype;
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
        public HttpResponseModel Create(WeightControlTypeViewModel weightControlTypeViewModel)
        {
            var response = new HttpResponseModel();
            var newcontroltype = new Weightcontroltype();
            newcontroltype.Name = weightControlTypeViewModel.name;
            newcontroltype.Description = weightControlTypeViewModel.description;
            newcontroltype.Creationdate = DateTime.Now;
            newcontroltype.Isactive = weightControlTypeViewModel.isactive;
            db.Weightcontroltypes.Add(newcontroltype);
            db.SaveChanges();
            response.WasSuccessful = true;
            response.StatusMessage = "El tipo de control de peso se creó exitosamente";
            return response;
        }

        public HttpResponseModel Update(WeightControlTypeViewModel weightControlTypeViewModel)
        {
            var controltype = ById(weightControlTypeViewModel.weightcontroltypeid);
            var response = new HttpResponseModel();
            if (controltype != null)
            {
                controltype.Name = weightControlTypeViewModel.name;
                controltype.Description = weightControlTypeViewModel.description;
                controltype.Isactive = weightControlTypeViewModel.isactive;
                controltype.Updatedate = DateTime.Now;
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
                controltype.Isactive = false;
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
