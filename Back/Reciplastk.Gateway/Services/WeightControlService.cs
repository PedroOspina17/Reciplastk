using Microsoft.EntityFrameworkCore;
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
        private Weightcontrol FindById(int? id)
        {
            var weightcontrol = db.Weightcontrols.Where(p => p.Isactive == true && p.Weightcontrolid == id).FirstOrDefault();
            return weightcontrol;

        }
        public HttpResponseModel GetAll()
        {
            var weightControl = db.Weightcontrols.Where(p => p.Isactive == true).ToList();
            var response = new HttpResponseModel();
            response.WasSuccessful = true;
            response.Data = weightControl;
            return response;
        }

        public HttpResponseModel GetById(int? id)
        {
            var weightcontrol = FindById(id);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro el Registro con el id buscado";
            }
            return response;
        }

        public HttpResponseModel Create(WeightControlViewModel model)
        {
            var weightcontrol = FindById(model.Weightcontrolid);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "El registro ya existe";
            }
            else
            {
                var newWeightControl = new Weightcontrol();
                newWeightControl.Employeeid = model.Employeeid;
                newWeightControl.Weightcontroltypeid = model.WeightControlTypeId;
                newWeightControl.Datestart = model.Datestart;
                newWeightControl.Dateend = model.Dateend;
                newWeightControl.Ispaid = model.Ispaid;
                newWeightControl.Creationdate = DateTime.Now;
                newWeightControl.Isactive = model.Isactive;
                db.Weightcontrols.Add(newWeightControl);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
                response.StatusMessage = "El dato fue agregado correctamente";

            }
            return response;

        }
        public HttpResponseModel Update(WeightControlViewModel model)
        {
            var weightcontrol = FindById(model.Weightcontrolid);
            var response = new HttpResponseModel();
            if (weightcontrol != null)
            {
                weightcontrol.Employeeid = model.Employeeid;
                weightcontrol.Weightcontroltypeid = model.WeightControlTypeId;
                weightcontrol.Datestart = model.Datestart;
                weightcontrol.Dateend = model.Dateend;
                weightcontrol.Ispaid = model.Ispaid;
                weightcontrol.Updatedate = DateTime.Now;
                weightcontrol.Isactive = model.Isactive;
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
            var weightcontrol = FindById(id);
            var response = new HttpResponseModel();
            if (weightcontrol == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No pudo ser eliminado";
            }
            else
            {
                weightcontrol.Dateend = DateTime.Now;
                weightcontrol.Isactive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.Data = weightcontrol;
            }
            return response;
        }



    }
}