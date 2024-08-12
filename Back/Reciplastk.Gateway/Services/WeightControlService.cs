using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class WeightControlService
    {

        private readonly ReciplastkContext db;

        public WeightControlService(ReciplastkContext db)
        {
            this.db = db;
        }

        private Weightcontrol GetById(int? id)
        {
            var weightcontrol = db.Weightcontrols.Where(p=>p.Isactive == true && p.Weightcontrolid == id).FirstOrDefault();
            return weightcontrol;

        }
        public HttpResponseModel GetAll()
        {
            var weightControl = db.Weightcontrols.Where(p=>p.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = weightControl;
            return response;
        }

        public HttpResponseModel GetOne(int? id)
        {
            var weightcontrol = GetById(id);
            var response = new HttpResponseModel();
            if(weightcontrol != null)
            {
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful= false;
                response.StatusMessage = "No se encontro el id buscado";
            }
            return response;
        }

        public HttpResponseModel Create(WeightControlViewModel model)
        {
            var weightcontrol = GetById(model.Weightcontrolid);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "ya existe ese id";
            }
            else
            {
                var newWeightControl = new Weightcontrol();
                newWeightControl.Alternateid = model.Alternateid;
                newWeightControl.Weight = model.Weight;
                newWeightControl.Totalpack = model.Totalpack;
                //newWeightControl.Datestart = model.Datastart;
                //newWeightControl.Dateend = model.Dataend;
                newWeightControl.Ispaid = model.Ispaid;
                db.Weightcontrols.Add(newWeightControl);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data= weightcontrol;
                response.StatusMessage = "El dato fue agregado correctamente";

                }
            return response;

        }
        public HttpResponseModel Update(WeightControlViewModel model)
        {
            var weightcontrol = GetById(model.Weightcontrolid);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                weightcontrol.Alternateid = model.Alternateid;
                weightcontrol.Weight = model.Weight;
                weightcontrol.Totalpack = model.Totalpack;
                weightcontrol.Ispaid = model.Ispaid;
                //weightcontrol.Datestart = model.Datestart;
                //weightcontrol.Dateend = model.Dateend;

                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No pudo ser modificado";
            }
            return response;
        }

        public HttpResponseModel Delete(int id)
        {
            var weightcontrol = GetById(id);
            var response = new HttpResponseModel();
            if(weightcontrol == null)
            {
                response.WasSuccessful= false;
                response.StatusMessage = "No pudo ser eliminado";

            }
            else
            {
                weightcontrol.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            return response;
        }



    }
}
